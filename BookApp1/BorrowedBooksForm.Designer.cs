namespace BookApp1
{
    partial class BorrowedBooksForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dataGridViewBorrowedBooks = new DataGridView();
            btnReturnBook = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBorrowedBooks).BeginInit();
            SuspendLayout();
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dataGridViewBorrowedBooks
            // 
            dataGridViewBorrowedBooks.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewBorrowedBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBorrowedBooks.Location = new Point(12, 12);
            dataGridViewBorrowedBooks.Name = "dataGridViewBorrowedBooks";
            dataGridViewBorrowedBooks.Size = new Size(643, 318);
            dataGridViewBorrowedBooks.TabIndex = 1;
            // 
            // btnReturnBook
            // 
            btnReturnBook.FlatStyle = FlatStyle.Popup;
            btnReturnBook.Location = new Point(566, 345);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(89, 23);
            btnReturnBook.TabIndex = 2;
            btnReturnBook.Text = "Return book";
            btnReturnBook.UseVisualStyleBackColor = true;
            btnReturnBook.Click += btnReturnBook_Click;
            // 
            // BorrowedBooksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 380);
            Controls.Add(btnReturnBook);
            Controls.Add(dataGridViewBorrowedBooks);
            Name = "BorrowedBooksForm";
            Text = "BorrowedBooksForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewBorrowedBooks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DataGridView dataGridViewBorrowedBooks;
        private Button btnReturnBook;
    }
}