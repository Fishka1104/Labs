using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookApp1.Classes;

namespace BookApp1
{
    public partial class EditBookForm : Form
    {
        int selectedBookId;

        private Book currentBook;

        public EditBookForm(Book book) 
        {
            InitializeComponent();
            currentBook = book;
            txtTitle.Text = book.Title;
            txtIsbn.Text = book.Isbn?.Code;
            txtPublisher.Text = book.Publisher?.Name;
            txtAuthor.Text = book.Author?.FullName;
            txtCategory.Text = book.Category?.Name;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            currentBook.Title = txtTitle.Text;
            currentBook.Isbn.Code = txtIsbn.Text;
            currentBook.Publisher.Name = txtPublisher.Text;
            currentBook.Author.FullName = txtAuthor.Text;
            currentBook.Category.Name = txtCategory.Text;

            currentBook.EditBook(currentBook); 

            this.Close();
        }

        void GetBookData()
        {
            Book? book = Book.GetBookData(selectedBookId); 
            if (book != null)
            {
                txtTitle.Text = book.Title;
                txtIsbn.Text = book.Isbn?.Code;
                txtPublisher.Text = book.Publisher?.Name;
                txtAuthor.Text = book.Author?.FullName;
                txtCategory.Text = book.Category?.Name;
            }
        }

        void EditBookData()
        {
            Book book = new Book
            {
                Id = selectedBookId,
                Title = txtTitle.Text,
                Isbn = new Isbn { Code = txtIsbn.Text },
                Publisher = new Publisher { Name = txtPublisher.Text },
                Author = new Author { FullName = txtAuthor.Text },
                Category = new Category { Name = txtCategory.Text }
            };

            book.EditBook(book);
        }
    }
}

