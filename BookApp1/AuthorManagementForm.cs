using System;
using System.Linq;
using System.Windows.Forms;
using BookApp1.Classes;

namespace BookApp1 {
    public partial class AuthorManagementForm : Form {
        private readonly IAuthorRepository authorRepository;

        public AuthorManagementForm(IAuthorRepository repository) {
            InitializeComponent();
            authorRepository = repository;
            LoadAuthors();
            ClearInputs(); 
        }

        private void LoadAuthors() {
            listBoxAuthors.DataSource = null;
            listBoxAuthors.DataSource = authorRepository.GetAuthors();
            listBoxAuthors.DisplayMember = "Name";
            listBoxAuthors.ValueMember = "Id";
        }

        private void listBoxAuthors_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBoxAuthors.SelectedItem is Author selectedAuthor) {
                txtName.Text = selectedAuthor.Name;
                dtpBirthDate.Value = selectedAuthor.BirthDate ?? DateTime.Today;
                dtpBirthDate.Checked = selectedAuthor.BirthDate.HasValue;
                dtpDeathDate.Value = selectedAuthor.DeathDate ?? DateTime.Today;
                dtpDeathDate.Checked = selectedAuthor.DeathDate.HasValue;
                txtNationality.Text = selectedAuthor.Nationality;
                txtGenres.Text = string.Join(", ", selectedAuthor.Genres);
            }
        }

        private void btnNew_Click(object sender, EventArgs e) {
            ClearInputs();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Author author = listBoxAuthors.SelectedItem as Author ?? new Author();

            author.Name = txtName.Text.Trim();
            author.BirthDate = dtpBirthDate.Checked ? dtpBirthDate.Value : null;
            author.DeathDate = dtpDeathDate.Checked ? dtpDeathDate.Value : null;
            author.Nationality = txtNationality.Text.Trim();
            author.Genres = txtGenres.Text.Split(',').Select(g => g.Trim()).ToList();

            var validationResults = ValidationService.Validate(author);

            if (validationResults.Any())
            {
                MessageBox.Show(string.Join("\n", validationResults.Select(r => r.ErrorMessage)), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (author.Id == 0)
                authorRepository.CreateAuthor(author);
            else
                authorRepository.UpdateAuthor(author);

            LoadAuthors();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (listBoxAuthors.SelectedItem is Author selectedAuthor) {
                if (MessageBox.Show($"Are you sure you want to delete {selectedAuthor.Name}?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    authorRepository.DeleteAuthor(selectedAuthor.Id);
                    LoadAuthors();
                    ClearInputs();
                }
            } else {
                MessageBox.Show("Please select an author to delete.");
            }
        }

        private void ClearInputs() {
            txtName.Text = "";
            dtpBirthDate.Value = DateTime.Today;
            dtpBirthDate.Checked = false;
            dtpDeathDate.Value = DateTime.Today;
            dtpDeathDate.Checked = false;
            txtNationality.Text = "";
            txtGenres.Text = "";
            listBoxAuthors.ClearSelected(); 
        }
    }
}