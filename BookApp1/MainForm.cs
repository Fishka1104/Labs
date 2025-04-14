using System;
using System.Windows.Forms;
using BookApp1.Classes;

namespace BookApp1 {
    public partial class MainForm : Form {
        private string userRole;
        private readonly IBookRepository bookRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly IPublisherRepository publisherRepository;

        public MainForm(string role) {
            InitializeComponent();
            userRole = role;

            // Створення зберігання для кожного типу даних
            var bookStorage = new JsonStorage<Book>("books.json");
            var authorStorage = new JsonStorage<Author>("authors.json");
            var publisherStorage = new JsonStorage<Publisher>("publishers.json");

            // Передача зберігання в репозиторії
            bookRepository = new BookRepository(bookStorage);
            authorRepository = new AuthorRepository(authorStorage);
            publisherRepository = new PublisherRepository(publisherStorage);


            SetPermissions();
            FillGridView();
        }

        private void SetPermissions() {
            if (userRole == "user") {
                btnOpenEditForm.Enabled = false;
                btnBookDelete.Enabled = false;
                btnNewForm.Enabled = false;
                btnManagePublishers.Enabled = false;
                btnManageAuthors.Enabled = false;
            }
        }

        void FillGridView() {
            if (dataGridViewBooks.Columns.Count == 0) {
                dataGridViewBooks.Columns.Add("Id", "ID");
                dataGridViewBooks.Columns.Add("Title", "Назва");
                dataGridViewBooks.Columns.Add("Isbn", "ISBN");
                dataGridViewBooks.Columns.Add("Author", "Автор");
                dataGridViewBooks.Columns.Add("Publisher", "Видавець");
                dataGridViewBooks.Columns.Add("Category", "Категорія");
            }

            dataGridViewBooks.Rows.Clear();
            List<Book> bookList = bookRepository.GetBooks();

            foreach (var book in bookList) {
                if (book != null) {
                    dataGridViewBooks.Rows.Add(
                        book.Id,
                        book.Title,
                        book.Isbn?.Code,
                        book.Author?.Name,
                        book.Publisher?.Name,
                        book.Category?.Name
                    );
                }
            }
        }

        private void btnNewForm_Click(object sender, EventArgs e) {
            NewBookForm formNewBook = new NewBookForm(bookRepository, authorRepository, publisherRepository);
            formNewBook.ShowDialog();
            FillGridView();
        }

        private void btnOpenEditForm_Click(object sender, EventArgs e) {
            if (dataGridViewBooks.SelectedRows.Count == 0) return;

            int bookId = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells[0].Value);
            Book? selectedBook = bookRepository.GetBookById(bookId);

            if (selectedBook != null) {
                EditBookForm editForm = new EditBookForm(selectedBook, bookRepository, authorRepository, publisherRepository);
                editForm.ShowDialog();
                FillGridView();
            }
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e) {
            string filterText = textBoxFilter.Text.Trim().ToLower();
            List<Book> books = bookRepository.GetBooks();

            var filteredBooks = books.Where(book =>
                book.Id.ToString().Contains(filterText) ||
                book.Title.ToLower().Contains(filterText) ||
                book.Isbn.Code.ToLower().Contains(filterText) ||
                (book.Author?.Name.ToLower().Contains(filterText) ?? false) ||
                (book.Publisher?.Name.ToLower().Contains(filterText) ?? false) || 
                book.Category.Name.ToLower().Contains(filterText)
            ).ToList();

            dataGridViewBooks.Rows.Clear();

            foreach (var book in filteredBooks) {
                dataGridViewBooks.Rows.Add(
                    book.Id,
                    book.Title,
                    book.Isbn.Code,
                    book.Author?.Name,
                    book.Publisher?.Name,
                    book.Category.Name
                );
            }
        }

        private void btnManageAuthors_Click(object sender, EventArgs e) {
            var authorForm = new AuthorManagementForm(authorRepository);
            authorForm.ShowDialog();
            FillGridView();
        }

        private void btnManagePublishers_Click(object sender, EventArgs e) {
            var publisherForm = new PublisherManagementForm(publisherRepository);
            publisherForm.ShowDialog();
            FillGridView();
        }
        private void btnBookDelete_Click(object sender, EventArgs e) {
            if (dataGridViewBooks.SelectedRows.Count == 0) return;
            int bookId = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells[0].Value);
            bookRepository.DeleteBook(bookId);
            FillGridView();
        }
    }
}