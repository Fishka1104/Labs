using BookApp1.Classes;
namespace BookApp1
{
    public partial class MainForm : Form
    {
        private string userRole;   //ця змінна зберігає роль користувача admin або user отриману під час входу
        public MainForm(string role)
        {
            InitializeComponent();
            userRole = role;
            SetPermissions();
        }

        private void SetPermissions()   //приймає role, зберігає її в userRole і викликає SetPermissions для налаштування доступу
        {
            if (userRole == "user")
            {
                btnOpenEditForm.Enabled = false;
                btnBookDelete.Enabled = false;        //Якщо користувач має роль user то він не може редагувати видаляти чи додавати книги
                btnNewForm.Enabled = false;
            }
        }


        public MainForm()
        {
            InitializeComponent();
            FillGridView();

        }

        void FillGridView()      //отримує список книг з файлу books.json і прив’язує його до dataGridViewBooks
        {
            List<Book> bookList = new List<Book>();
            Book book = new Book();
            bookList = book.GetBooks();
            dataGridViewBooks.DataSource = bookList;
        }

        private void btnNewForm_Click(object sender, EventArgs e)        //При натисканні відкривається NewBookForm у якому можна додати нову книгу
        {
            NewBookForm formNewBook = new NewBookForm();
            formNewBook.ShowDialog();
        }

        private void MainForm_Activated(object sender, EventArgs e)      //викликається коли MainForm знову стає активним оновлюючи список книг
        {
            FillGridView();
        }

        private void btnOpenEditForm_Click(object sender, EventArgs e)
        {
            EditBook();                                                  //відкриває EditBookForm для редагування вибраної книги
        }

        void EditBook()
        {
            int bookId;
            bookId = (int)dataGridViewBooks.CurrentRow.Cells[0].Value;
            EditBookForm formEditBook = new EditBookForm(bookId);
            formEditBook.ShowDialog();
        }

        private void btnBookDelete_Click(object sender, EventArgs e)
        {
            DeleteBook();
        }

        void DeleteBook()                                //показується повідомлення-підтвердження і якщо погодитись книга видаляється
        {
            int bookId;
            bookId = (int)dataGridViewBooks.CurrentRow.Cells[0].Value;
            string? bookTitle = dataGridViewBooks.CurrentRow.Cells[1].Value.ToString();
            string message = "Are you sure that you want to delete the book '" + bookTitle + "'?";
            DialogResult dr = MessageBox.Show(message, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Book book = new Book();
                book.DeleteBook(bookId);
                FillGridView();
            }
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBoxFilter.Text.Trim().ToLower();
            List<Book> bookList = new Book().GetBooks(); // Отримуємо всі книги

            var filteredList = bookList.Where(b =>
                b.BookId.ToString().Contains(filterText) ||   // Пошук по ID (числа)
                b.Title.ToLower().Contains(filterText) ||     // Пошук по назві книги
                b.Isbn.ToLower().Contains(filterText) ||      // Пошук по ISBN
                b.PublisherName.ToLower().Contains(filterText) || // Пошук по видавцю
                b.AuthorName.ToLower().Contains(filterText) || // Пошук по автору
                b.CategoryName.ToLower().Contains(filterText)   // Пошук по категорії
            ).ToList();

            dataGridViewBooks.DataSource = filteredList;
        }
    }
}

