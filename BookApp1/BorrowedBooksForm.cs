using System;
using System.Windows.Forms;
using BookApp1.Classes;

namespace BookApp1 {
    public partial class BorrowedBooksForm : Form {
        private readonly UserBorrowedBookRepository _userBorrowedBookRepository;
        private readonly string _username;

        public BorrowedBooksForm(UserBorrowedBookRepository userBorrowedBookRepository, string username) {
            InitializeComponent();
            _userBorrowedBookRepository = userBorrowedBookRepository;
            _username = username;
            LoadBorrowedBooks();
        }

        private void LoadBorrowedBooks() {
            if (dataGridViewBorrowedBooks.Columns.Count == 0) {
                dataGridViewBorrowedBooks.Columns.Add("Id", "ID");
                dataGridViewBorrowedBooks.Columns.Add("Title", "Назва");
                dataGridViewBorrowedBooks.Columns.Add("Isbn", "ISBN");
                dataGridViewBorrowedBooks.Columns.Add("Author", "Автор");
                dataGridViewBorrowedBooks.Columns.Add("Publisher", "Видавець");
                dataGridViewBorrowedBooks.Columns.Add("Category", "Категорія");
            }

            dataGridViewBorrowedBooks.Rows.Clear();

            var borrowedBooks = _userBorrowedBookRepository.GetBorrowedBooks(_username);

            foreach (var book in borrowedBooks) {
                if (book != null) {
                    dataGridViewBorrowedBooks.Rows.Add(
                        book.BookId,
                        book.Title,
                        book.Isbn,
                        book.Author,
                        book.Publisher,
                        book.Category
                    );
                }
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e) {
            if (dataGridViewBorrowedBooks.SelectedRows.Count == 0) {
                MessageBox.Show("Будь ласка, виберіть книгу для повернення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int bookId;
            try {
                bookId = Convert.ToInt32(dataGridViewBorrowedBooks.SelectedRows[0].Cells["Id"].Value);
            } catch (FormatException) {
                MessageBox.Show("Неправильний формат ID книги.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _userBorrowedBookRepository.ReturnBook(_username, bookId);
            LoadBorrowedBooks();
            MessageBox.Show("Книга успішно повернута.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}