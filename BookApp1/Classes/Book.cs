using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BookApp1.Classes
{
    public class Book : BaseEntity, IBookOperations
    {
        public string Title { get; set; }
        public Isbn Isbn { get; set; }
        public Publisher Publisher { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }

        public int BookId => Id;

        private static string filePath = "books.json";

        private static List<Book> LoadBooks()
        {
            if (!File.Exists(filePath)) return new List<Book>();
            string json = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, 
                IncludeFields = true,              
                WriteIndented = true
            };

            return JsonSerializer.Deserialize<List<Book>>(json, options) ?? new List<Book>();
        }

        private static void SaveBooks(List<Book> books)
        {
            string json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public List<Book> GetBooks()
        {
            return LoadBooks();
        }

        public void CreateBook(Book book)
        {
            var books = LoadBooks();
            book.Id = books.Count > 0 ? books[^1].Id + 1 : 1; 
            books.Add(book);
            SaveBooks(books);
        }

        public void EditBook(Book book)
        {
            var books = LoadBooks();
            var index = books.FindIndex(b => b.Id == book.Id);
            if (index != -1)
            {
                books[index] = book;
                SaveBooks(books);
            }
        }

        public void DeleteBook(int bookId)
        {
            var books = LoadBooks();
            books.RemoveAll(b => b.Id == bookId);
            SaveBooks(books);
        }

        public static Book? GetBookData(int bookId)
        {
            return LoadBooks().FirstOrDefault(b => b.Id == bookId);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Book: {Title}, ISBN: {Isbn.Code}, Author: {Author.FullName}, Publisher: {Publisher.Name}, Category: {Category.Name}");
        }
    }
}


