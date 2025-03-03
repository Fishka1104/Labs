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
            this.Close();
        }

        void SaveBookData()
        {
            Book book = new Book
            {
                Title = txtTitle.Text,
                Isbn = new Isbn { Code = txtIsbn.Text },
                Publisher = new Publisher { Name = txtPublisher.Text },
                Author = new Author { FullName = txtAuthor.Text },
                Category = new Category { Name = txtCategory.Text }
            };

            book.CreateBook(book);
        }
    }
}

