using System;
using System.Windows.Forms;
using BookApp1.Classes;

namespace BookApp1 {
    public partial class NewBookForm : Form {
        private readonly IBookRepository bookRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly IPublisherRepository publisherRepository;

        public NewBookForm(IBookRepository bookRepo, IAuthorRepository authorRepo, IPublisherRepository publisherRepo) {
            InitializeComponent();
            bookRepository = bookRepo;
            authorRepository = authorRepo;
            publisherRepository = publisherRepo;
            SetupAuthorComboBox();
            SetupPublisherComboBox();
        }

        private void SetupAuthorComboBox() {
            comboBoxAuthors.DataSource = authorRepository.GetAuthors();
            comboBoxAuthors.DisplayMember = "Name";
            comboBoxAuthors.ValueMember = "Id";
        }

        private void SetupPublisherComboBox() {
            comboBoxPublishers.DataSource = publisherRepository.GetPublishers();
            comboBoxPublishers.DisplayMember = "Name";
            comboBoxPublishers.ValueMember = "Id";
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

            var newBook = new Book
            {
                Title = txtTitle.Text.Trim(),
                Author = selectedAuthor,
                AuthorId = selectedAuthor.Id,
                Publisher = selectedPublisher,
                PublisherId = selectedPublisher.Id,
                Category = new Category 
                {
                    Name = txtCategory.Text.Trim()
                },
                Isbn = new Isbn
                {
                    Code = txtIsbn.Text.Trim()
                }
            };

            var validationResults = ValidationService.Validate(newBook);

            if (validationResults.Any())
            {
                MessageBox.Show(string.Join("\n", validationResults.Select(r => r.ErrorMessage)), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bookRepository.CreateBook(newBook);
            this.Close();
        }

        void SaveBookData() {
            var selectedAuthor = (Author)comboBoxAuthors.SelectedItem;
            var selectedPublisher = (Publisher)comboBoxPublishers.SelectedItem;
            if (selectedAuthor == null || selectedPublisher == null) {
                MessageBox.Show("Please select an author and a publisher.");
                return;
            }

            Book book = new Book {
                Title = txtTitle.Text,
                Isbn = new Isbn { Code = txtIsbn.Text },
                Publisher = selectedPublisher,
                PublisherId = selectedPublisher.Id,
                Author = selectedAuthor,
                AuthorId = selectedAuthor.Id,
                Category = new Category { Name = txtCategory.Text }
            };

            bookRepository.CreateBook(book);
        }
    }
}