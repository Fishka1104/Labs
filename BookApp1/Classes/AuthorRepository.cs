using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BookApp1.Classes {

    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(IDataStorage<Author> storage) : base(storage)
        {
        }

        public List<Author> GetAuthors()
        {
            return base.GetAll();
        }

        public void CreateAuthor(Author author)
        {
            base.Add(author);
        }

        public void UpdateAuthor(Author author)
        {
            base.Update(author);
        }

        public void DeleteAuthor(int authorId)
        {
            base.Delete(authorId);
        }

        public Author? GetAuthorById(int authorId)
        {
            return base.GetById(authorId);
        }
    }
}