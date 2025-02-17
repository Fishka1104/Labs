using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookApp1.Classes;

namespace BookApp1
{
    public partial class NewBookForm : Form
    {
        public NewBookForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveBookData();
            GotoMainForm();
        }

        void SaveBookData()          //дані з текстових полів txtTitle, txtIsbn... записуються у новий об'єкт Book
        {
            Book book = new Book();
            book.Title = txtTitle.Text;
            book.Isbn = txtIsbn.Text;
            book.PublisherName = txtPublisher.Text;
            book.AuthorName = txtAuthor.Text;
            book.CategoryName = txtCategory.Text;
            book.CreateBook(book);   //Викликається щоб зберегти книгу у books.json
        }
        void GotoMainForm()
        {
            this.Close(); //після додавання книга зберігається і форма закривається
        }
    }
}
