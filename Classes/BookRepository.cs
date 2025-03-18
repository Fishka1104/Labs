using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BookApp1.Classes {
    public class BookRepository : IBookRepository {
        private static readonly string filePath = "books.json";
        private readonly IAuthorRepository authorRepository;
        private readonly IPublisherRepository publisherRepository;

        public BookRepository() {
            authorRepository = new AuthorRepository();
            publisherRepository = new PublisherRepository(); // Add this
        }

        private List<Book> LoadBooks() {
            if (!File.Exists(filePath)) return new List<Book>();
            string json = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
                WriteIndented = true
            };

            var books = JsonSerializer.Deserialize<List<Book>>(json, options) ?? new List<Book>();
            foreach (var book in books) {
                book.Author = authorRepository.GetAuthorById(book.AuthorId);
                book.Publisher = publisherRepository.GetPublisherById(book.PublisherId); // Add this
            }
            return books;
        }

        private static void SaveBooks(List<Book> books) {
            foreach (var book in books) {
                book.AuthorId = book.Author?.Id ?? 0;
                book.PublisherId = book.Publisher?.Id ?? 0; // Add this
            }
            string json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public List<Book> GetBooks() {
            return LoadBooks();
        }

        public void CreateBook(Book book) {
            var books = LoadBooks();
            book.Id = books.Count > 0 ? books[^1].Id + 1 : 1;
            books.Add(book);
            SaveBooks(books);
        }

        public void EditBook(Book book) {
            var books = LoadBooks();
            var index = books.FindIndex(b => b.Id == book.Id);
            if (index != -1) {
                books[index] = book;
                SaveBooks(books);
            }
        }

        public void DeleteBook(int bookId) {
            var books = LoadBooks();
            books.RemoveAll(b => b.Id == bookId);
            SaveBooks(books);
        }

        public Book? GetBookById(int bookId) {
            return LoadBooks().FirstOrDefault(b => b.Id == bookId);
        }
    }
}