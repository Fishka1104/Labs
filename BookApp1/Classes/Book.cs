using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace BookApp1.Classes
{
    public class Book   //клас Book працює з JSON-файлом books.json де зберігаються всі книги
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Isbn { get; set; }
        public string? PublisherName { get; set; }
        public string? AuthorName { get; set; }
        public string? CategoryName { get; set; }   //кожна книга має BookId Title Isbn PublisherName AuthorName та CategoryName

        private static string filePath = "books.json";

        private static List<Book> LoadBooks()
        {
            if (!File.Exists(filePath)) return new List<Book>();
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
        }

        private static void SaveBooks(List<Book> books)   //ккщо books.json існує він читається і перетворюється у список List<Book>
        {
            string json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public List<Book> GetBooks()
        {
            return LoadBooks();
        }

        public void CreateBook(Book book) //кожній новій книзі призначається BookId, і вона додається до списку
        {
            var books = LoadBooks();
            book.BookId = books.Count > 0 ? books[^1].BookId + 1 : 1; //генеруємо ID
            books.Add(book);
            SaveBooks(books);
        }

        public Book? GetBookData(int bookId)
        {
            return LoadBooks().Find(b => b.BookId == bookId);
        }

        public void EditBook(Book book) //книга знаходиться за BookId та оновлюється
        {
            var books = LoadBooks();
            var index = books.FindIndex(b => b.BookId == book.BookId);
            if (index != -1)
            {
                books[index] = book;
                SaveBooks(books);
            }
        }

        public void DeleteBook(int bookId)  //книга видаляється зі списку за BookId
        {
            var books = LoadBooks();
            books.RemoveAll(b => b.BookId == bookId);
            SaveBooks(books);
        }
    }
}
