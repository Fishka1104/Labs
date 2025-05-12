using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BookApp1.Classes {
    public class BookRepository : GenericRepository<Book>, IBookRepository {
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;

        public BookRepository(IDataStorage<Book> storage, IAuthorRepository authorRepository, IPublisherRepository publisherRepository)
            : base(storage) {
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public List<Book> GetBooks() {
            var books = base.GetAll();
            foreach (var book in books) {
                book.Author = _authorRepository.GetAuthorById(book.AuthorId);
                book.Publisher = _publisherRepository.GetPublisherById(book.PublisherId);
            }
            return books;
        }

        public void CreateBook(Book book) {
            base.Add(book);
        }

        public void EditBook(Book book) {
            base.Update(book);
        }

        public void DeleteBook(int bookId) {
            base.Delete(bookId);
        }

        public Book? GetBookById(int bookId) {
            var book = base.GetById(bookId);
            if (book != null) {
                book.Author = _authorRepository.GetAuthorById(book.AuthorId);
                book.Publisher = _publisherRepository.GetPublisherById(book.PublisherId);
            }
            return book;
        }

        public void BorrowBook(int bookId) {
            var book = base.GetById(bookId);
            if (book != null) {
                base.Delete(bookId);
            }
        }

        public void ReturnBook(BorrowedBook borrowedBook) {
            try {
                if (borrowedBook == null) {
                    Console.WriteLine("Error: borrowedBook is null");
                    return;
                }

                // Validate foreign keys
                var author = _authorRepository.GetAuthorById(borrowedBook.AuthorId);
                if (author == null) {
                    Console.WriteLine($"Error: AuthorId {borrowedBook.AuthorId} does not exist");
                    return;
                }
                var publisher = _publisherRepository.GetPublisherById(borrowedBook.PublisherId);
                if (publisher == null) {
                    Console.WriteLine($"Error: PublisherId {borrowedBook.PublisherId} does not exist");
                    return;
                }

                var book = new Book {
                    Id = borrowedBook.BookId,
                    Title = borrowedBook.Title ?? "Unknown",
                    AuthorId = borrowedBook.AuthorId,
                    PublisherId = borrowedBook.PublisherId,
                    Isbn = new Isbn { Code = borrowedBook.Isbn ?? "" },
                    Category = new Category { Name = borrowedBook.Category ?? "Unknown" }
                };

                var existingBook = base.GetById(book.Id);
                if (existingBook == null) {
                    Console.WriteLine($"Adding book {book.Id}: {book.Title} to Books table");
                    base.Add(book);
                } else {
                    Console.WriteLine($"Updating book {book.Id}: {book.Title} in Books table");
                    base.Update(book);
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error in ReturnBook: {ex.Message}");
                throw; // Re-throw to catch in caller
            }
        }
    }
}