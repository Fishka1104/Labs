using BookApp1.Classes;
namespace BookApp1
{
    public partial class MainForm : Form
    {


        private string userRole;

        public MainForm(string role)
        {
            InitializeComponent(); 
            userRole = role;
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
            }
        }

        void FillGridView()
        {
           
            if (dataGridViewBooks.Columns.Count == 0)
            {
                dataGridViewBooks.Columns.Add("Id", "ID");
                dataGridViewBooks.Columns.Add("Title", "Назва");
                dataGridViewBooks.Columns.Add("Isbn", "ISBN");
                dataGridViewBooks.Columns.Add("Author", "Автор");
                dataGridViewBooks.Columns.Add("Publisher", "Видавець");
                dataGridViewBooks.Columns.Add("Category", "Категорія");
            }

            dataGridViewBooks.Rows.Clear();

            List<Book> bookList = new Book().GetBooks();

            foreach (var book in bookList)
            {
                if (book != null) 
                {
                    dataGridViewBooks.Rows.Add(
                        book.Id,
                        book.Title,
                        book.Isbn?.Code,
                        book.Author?.FullName,
                        book.Publisher?.Name,
                        book.Category?.Name
                    );
                }
            }
        }

        private void btnNewForm_Click(object sender, EventArgs e)
        {
            NewBookForm formNewBook = new NewBookForm();
            formNewBook.ShowDialog();
            FillGridView();
        }

        private void btnOpenEditForm_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0) return;

            int bookId = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells[0].Value);

            Book? selectedBook = Book.GetBookData(bookId);
            if (selectedBook != null)
            {
                EditBookForm editForm = new EditBookForm(selectedBook);
                editForm.ShowDialog();
                FillGridView();
            }
        }

        private void btnBookDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0) return;
            int bookId = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells[0].Value);
            Book book = new Book();
            book.DeleteBook(bookId);
            FillGridView();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBoxFilter.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dataGridViewBooks.Rows)
            {
                if (row.IsNewRow) continue; 

                bool visible = false;
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value != null && row.Cells[i].Value.ToString().ToLower().Contains(filterText))
                    {
                        visible = true;
                        break;
                    }
                }
                row.Visible = visible;
            }
        }
    }
}



