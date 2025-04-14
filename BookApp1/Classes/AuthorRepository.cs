using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BookApp1.Classes {

    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDataStorage<Author> _storage;

        public AuthorRepository(IDataStorage<Author> storage)
        {
            _storage = storage;
        }

        public List<Author> GetAuthors()
        {
            return _storage.GetAll();
        }

        public void CreateAuthor(Author author)
        {
            _storage.Add(author);
            _storage.Save();
        }

        public void UpdateAuthor(Author author)
        {
            _storage.Update(author);
            _storage.Save();
        }

        public void DeleteAuthor(int authorId)
        {
            _storage.Delete(authorId);
            _storage.Save();
        }

        public Author? GetAuthorById(int authorId)
        {
            return _storage.GetById(authorId);
        }
    }
}