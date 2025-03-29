using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp1.Classes
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        void CreateBook(Book book);
        void EditBook(Book book);
        void DeleteBook(int bookId);
        Book? GetBookById(int bookId);
    }
}
