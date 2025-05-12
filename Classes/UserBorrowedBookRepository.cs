using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp1.Classes {
    public class UserBorrowedBookRepository {
        private readonly IDataStorage<User> _userStorage;
        private readonly IBookRepository _bookRepository;

        public UserBorrowedBookRepository(IDataStorage<User> userStorage, IBookRepository bookRepository) {
            _userStorage = userStorage;
            _bookRepository = bookRepository;
        }

        public void BorrowBook(string username, Book book) {
            var users = _userStorage.GetAll();
            var user = users.FirstOrDefault(u => u.Username == username);

            if (user != null) {
                var borrowedBook = new BorrowedBook {
                    BookId = book.Id,
                    Title = book.Title,
                    Isbn = book.Isbn?.Code ?? "",
                    Author = book.Author?.Name ?? "Unknown",
                    Publisher = book.Publisher?.Name ?? "Unknown",
                    Category = book.Category?.Name ?? "Unknown",
                    AuthorId = book.AuthorId,
                    PublisherId = book.PublisherId,
                    CategoryId = book.Category?.Id ?? 0 
                };
                user.BorrowedBooks.Add(borrowedBook);
                _userStorage.Save();
            }
        }

        public void ReturnBook(string username, int bookId) {
            var users = _userStorage.GetAll();
            var user = users.FirstOrDefault(u => u.Username == username);

            if (user != null) {
                var borrowedBook = user.BorrowedBooks.FirstOrDefault(b => b.BookId == bookId);
                if (borrowedBook != null) {
                    user.BorrowedBooks.Remove(borrowedBook);
                    _userStorage.Save();
                    _bookRepository.ReturnBook(borrowedBook);
                }
            }
        }

        public List<BorrowedBook> GetBorrowedBooks(string username) {
            var users = _userStorage.GetAll();
            var user = users.FirstOrDefault(u => u.Username == username);
            return user?.BorrowedBooks ?? new List<BorrowedBook>();
        }
    }
}