using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookApp1.Classes
{
    public interface IBookOperations
    {
        List<Book> GetBooks();
        void CreateBook(Book book);
        void EditBook(Book book);
        void DeleteBook(int bookId);
    }
}

//Визначає операції для роботи з книгами, які реалізовані в Book
