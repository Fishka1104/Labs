using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BookApp1.Classes {
    public class AuthorRepository : IAuthorRepository {
        private static readonly string filePath = "authors.json";

        private static List<Author> LoadAuthors() {
            if (!File.Exists(filePath)) return new List<Author>();
            string json = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
                WriteIndented = true
            };

            return JsonSerializer.Deserialize<List<Author>>(json, options) ?? new List<Author>();
        }

        private static void SaveAuthors(List<Author> authors) {
            string json = JsonSerializer.Serialize(authors, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public List<Author> GetAuthors() {
            return LoadAuthors();
        }

        public void CreateAuthor(Author author) {
            var authors = LoadAuthors();
            author.Id = authors.Count > 0 ? authors[^1].Id + 1 : 1;
            authors.Add(author);
            SaveAuthors(authors);
        }

        public void UpdateAuthor(Author author) {
            var authors = LoadAuthors();
            var index = authors.FindIndex(a => a.Id == author.Id);
            if (index != -1) {
                authors[index] = author;
                SaveAuthors(authors);
            }
        }

        public void DeleteAuthor(int authorId) {
            var authors = LoadAuthors();
            authors.RemoveAll(a => a.Id == authorId);
            SaveAuthors(authors);
        }

        public Author? GetAuthorById(int authorId) {
            return LoadAuthors().FirstOrDefault(a => a.Id == authorId);
        }
    }
}