using System;
using System.Windows.Forms;
using BookApp1.Classes;

namespace BookApp1 {
    public partial class EditBookForm : Form {
        private readonly IBookRepository bookRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly IPublisherRepository publisherRepository;
        private Book currentBook;

        public EditBookForm(Book book, IBookRepository bookRepo, IAuthorRepository authorRepo, IPublisherRepository publisherRepo) {
            InitializeComponent();
            currentBook = book;
            bookRepository = bookRepo;
            authorRepository = authorRepo;
            publisherRepository = publisherRepo;

            txtTitle.Text = book.Title;
            txtIsbn.Text = book.Isbn?.Code;
            txtCategory.Text = book.Category?.Name;
            SetupAuthorComboBox();
            SetupPublisherComboBox();
        }

        private void SetupAuthorComboBox() {
            comboBoxAuthors.DataSource = authorRepository.GetAuthors();
            comboBoxAuthors.DisplayMember = "Name";
            comboBoxAuthors.ValueMember = "Id";
            comboBoxAuthors.SelectedItem = authorRepository.GetAuthorById(currentBook.AuthorId);
        }

        private void SetupPublisherComboBox() {
            comboBoxPublishers.DataSource = publisherRepository.GetPublishers();
            comboBoxPublishers.DisplayMember = "Name";
            comboBoxPublishers.ValueMember = "Id";
            comboBoxPublishers.SelectedItem = publisherRepository.GetPublisherById(currentBook.PublisherId);
        }

        private void btnAddAuthor_Click(object sender, EventArgs e) {
            var authorForm = new AuthorManagementForm(authorRepository);
            authorForm.ShowDialog();
            SetupAuthorComboBox();
        }

        private void btnAddPublisher_Click(object sender, EventArgs e) {
            var publisherForm = new PublisherManagementForm(publisherRepository);
            publisherForm.ShowDialog();
            SetupPublisherComboBox();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            var selectedAuthor = (Author)comboBoxAuthors.SelectedItem;
            var selectedPublisher = (Publisher)comboBoxPublishers.SelectedItem;
            if (selectedAuthor == null || selectedPublisher == null)
            {
                MessageBox.Show("Будь ласка, виберіть автора і видавця.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentBook.Title = txtTitle.Text.Trim();

            if (currentBook.Isbn == null)
            {
                currentBook.Isbn = new Isbn();
            }
            currentBook.Isbn.Code = txtIsbn.Text.Trim();

            currentBook.Publisher = selectedPublisher;
            currentBook.PublisherId = selectedPublisher.Id;
            currentBook.Author = selectedAuthor;
            currentBook.AuthorId = selectedAuthor.Id;

            if (currentBook.Category == null)
            {
                currentBook.Category = new Category();
            }
            currentBook.Category.Name = txtCategory.Text.Trim();

            var validationResults = ValidationService.Validate(currentBook);

            if (validationResults.Any())
            {
                MessageBox.Show(string.Join("\n", validationResults.Select(r => r.ErrorMessage)), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bookRepository.EditBook(currentBook);
            this.Close();
        }
    }
}