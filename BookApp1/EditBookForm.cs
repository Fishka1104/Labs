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
        public EditBookForm(int bookId)
        {
            InitializeComponent();
            selectedBookId = bookId;
            GetBookData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EditBookData();
            this.Close();
        }

        void GetBookData()    //ця форма відкривається для редагування книги
        {
            Book book = new Book();
            book = book.GetBookData(selectedBookId); //знаходить книгу у books.json і заповнює текстові поля
            txtTitle.Text = book.Title;
            txtIsbn.Text = book.Isbn;
            txtPublisher.Text = book.PublisherName;
            txtAuthor.Text = book.AuthorName;
            txtCategory.Text = book.CategoryName;
        }

        void EditBookData()  //нові дані зберігаються в books.json через EditBook(book)
        {
            Book book = new Book();
            book.BookId = selectedBookId;
            book.Title = txtTitle.Text;
            book.Isbn = txtIsbn.Text;
            book.PublisherName = txtPublisher.Text;
            book.AuthorName = txtAuthor.Text;
            book.CategoryName = txtCategory.Text;
            book.EditBook(book);
        }

    }
}
