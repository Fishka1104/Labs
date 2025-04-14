using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BookApp1.Classes {

    public class BookRepository : IBookRepository
    {
        private readonly IDataStorage<Book> _storage;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;

        
        public BookRepository(IDataStorage<Book> storage)
        {
            _storage = storage;
            _authorRepository = new AuthorRepository(new JsonStorage<Author>("authors.json"));
            _publisherRepository = new PublisherRepository(new JsonStorage<Publisher>("publishers.json"));
        }

        public List<Book> GetBooks()
        {
            var books = _storage.GetAll();
            foreach (var book in books)
            {
                book.Author = _authorRepository.GetAuthorById(book.AuthorId);
                book.Publisher = _publisherRepository.GetPublisherById(book.PublisherId);
            }
            return books;
        }

        public void CreateBook(Book book)
        {
            _storage.Add(book);
            _storage.Save();
        }

        public void EditBook(Book book)
        {
            _storage.Update(book);
            _storage.Save();
        }

        public void DeleteBook(int bookId)
        {
            _storage.Delete(bookId);
            _storage.Save();
        }

        public Book? GetBookById(int bookId)
        {
            return _storage.GetById(bookId);
        }
    }
}