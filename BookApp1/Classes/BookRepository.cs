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
            var book = new Book {
                Id = borrowedBook.BookId, 
                Title = borrowedBook.Title,
                AuthorId = borrowedBook.AuthorId,
                PublisherId = borrowedBook.PublisherId,
                CategoryId = borrowedBook.CategoryId,
                Isbn = new Isbn { Code = borrowedBook.Isbn }
            };
            var existingBook = base.GetById(book.Id);
            if (existingBook == null) {
                base.Add(book); 
            } else {
                base.Update(book); 
            }
        }
    }
}