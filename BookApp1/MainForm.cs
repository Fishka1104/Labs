using System;
using System.Windows.Forms;
using BookApp1.Classes; 

namespace BookApp1
{

    public partial class MainForm : Form
    {
        private User _activeUser;
        private string userRole;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly UserBorrowedBookRepository _userBorrowedBookRepository;
       

        public MainForm(string role, User activeUser) {
            InitializeComponent();
            userRole = role;
            _activeUser = activeUser;

            // Створення зберігання для кожного типу даних
            var bookStorage = new SQLiteStorage<Book>("Books");
            var authorStorage = new SQLiteStorage<Author>("Authors"); 
            var publisherStorage = new SQLiteStorage<Publisher>("Publishers"); 
            var userStorage = new SQLiteStorage<User>("Users"); 

            // Створення репозиторіїв
            var authorRepo = new AuthorRepository(authorStorage);
            var publisherRepo = new PublisherRepository(publisherStorage);
            _bookRepository = new BookRepository(bookStorage, authorRepo, publisherRepo);
            var userRepository = new UserRepository(userStorage);

            // Присвоєння репозиторіїв
            _authorRepository = authorRepo;
            _publisherRepository = publisherRepo;
            _userBorrowedBookRepository = new UserBorrowedBookRepository(userStorage, _bookRepository);

            SetPermissions();
            FillGridView();
        }

        private void SetPermissions()
        {
            if (userRole == "user")
            {
                btnOpenEditForm.Enabled = false;
                btnBookDelete.Enabled = false;
                btnNewForm.Enabled = false;
                btnManagePublishers.Enabled = false;
                btnManageAuthors.Enabled = false;
            }
        }

        private void FillGridView() {
            if (dataGridViewBooks.Columns.Count == 0) {
                dataGridViewBooks.Columns.Add("Id", "ID");
                dataGridViewBooks.Columns.Add("Title", "Назва");
                dataGridViewBooks.Columns.Add("Isbn", "ISBN");
                dataGridViewBooks.Columns.Add("Author", "Автор");
                dataGridViewBooks.Columns.Add("Publisher", "Видавець");
                dataGridViewBooks.Columns.Add("Category", "Категорія");
            }

            dataGridViewBooks.Rows.Clear();
            List<Book> bookList = _bookRepository.GetBooks();

            foreach (var book in bookList) {
                if (book != null) {
                    dataGridViewBooks.Rows.Add(
                        book.Id,
                        book.Title,
                        book.Isbn?.Code ?? "N/A",
                        book.Author?.Name ?? "Unknown",
                        book.Publisher?.Name ?? "Unknown",
                        book.Category?.Name ?? "Unknown"
                    );
                }
            }
        }

        private void btnNewForm_Click(object sender, EventArgs e)
        {
            NewBookForm formNewBook = new NewBookForm(_bookRepository, _authorRepository, _publisherRepository);
            formNewBook.ShowDialog();
            FillGridView();
        }

        private void btnOpenEditForm_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0) return;

            int bookId = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells[0].Value);
            Book? selectedBook = _bookRepository.GetBookById(bookId);

            if (selectedBook != null)
            {
                EditBookForm editForm = new EditBookForm(selectedBook, _bookRepository, _authorRepository, _publisherRepository);
                editForm.ShowDialog();
                FillGridView();
            }
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBoxFilter.Text.Trim().ToLower();
            List<Book> books = _bookRepository.GetBooks();

            var filteredBooks = books.Where(book =>
                book.Title.ToLower().Contains(filterText) ||
                book.Isbn.Code.ToLower().Contains(filterText) ||
                (book.Author?.Name?.ToLower().Contains(filterText) ?? false) || 
                (book.Publisher?.Name?.ToLower().Contains(filterText) ?? false) || 
                (book.Category?.Name?.ToLower().Contains(filterText) ?? false) 
            ).ToList();

            dataGridViewBooks.Rows.Clear();
            foreach (var book in filteredBooks)
            {
                dataGridViewBooks.Rows.Add(
                    book.Id,
                    book.Title,
                    book.Isbn.Code,
                    book.Author?.Name ?? "Unknown", 
                    book.Publisher?.Name ?? "Unknown",
                    book.Category?.Name ?? "Unknown" 
                );
            }
        }

        private void btnManageAuthors_Click(object sender, EventArgs e)
        {
            var authorForm = new AuthorManagementForm(_authorRepository);
            authorForm.ShowDialog();
            FillGridView();
        }

        private void btnManagePublishers_Click(object sender, EventArgs e)
        {
            var publisherForm = new PublisherManagementForm(_publisherRepository);
            publisherForm.ShowDialog();
            FillGridView();
        }

        private void btnBookDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0) return;
            int bookId = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells[0].Value);
            _bookRepository.DeleteBook(bookId);
            FillGridView();
        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0) return;

            int bookId = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells[0].Value);
            Book? selectedBook = _bookRepository.GetBookById(bookId);

            if (selectedBook != null)
            {
                _bookRepository.BorrowBook(bookId);
                _userBorrowedBookRepository.BorrowBook(_activeUser.Username, selectedBook);
                MessageBox.Show("Книга успішно взята.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGridView(); 
            }
        }

        private void btnViewBorrowedBooks_Click(object sender, EventArgs e) {
            var borrowedBooksForm = new BorrowedBooksForm(_userBorrowedBookRepository, _activeUser.Username);
            borrowedBooksForm.ShowDialog();
            FillGridView(); 
        }
    }
}
