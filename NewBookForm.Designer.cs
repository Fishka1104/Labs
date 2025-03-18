namespace BookApp1 {
    partial class NewBookForm {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewBookForm));
            txtTitle = new TextBox();
            txtIsbn = new TextBox();
            txtCategory = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            comboBoxAuthors = new ComboBox();
            btnAddAuthor = new Button();
            comboBoxPublishers = new ComboBox();
            btnAddPublisher = new Button();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Location = new Point(12, 36);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(357, 23);
            txtTitle.TabIndex = 1;
            // 
            // txtIsbn
            // 
            txtIsbn.BorderStyle = BorderStyle.FixedSingle;
            txtIsbn.Location = new Point(12, 89);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(357, 23);
            txtIsbn.TabIndex = 2;
            // 
            // txtCategory
            // 
            txtCategory.BorderStyle = BorderStyle.FixedSingle;
            txtCategory.Location = new Point(12, 237);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(357, 23);
            txtCategory.TabIndex = 5;
            // Removed: txtCategory.TextChanged += txtCategory_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 5;
            label1.Text = "Title:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 71);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 6;
            label2.Text = "ISBN:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 7;
            label3.Text = "Publisher:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 180);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 8;
            label4.Text = "Author:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 219);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 9;
            label5.Text = "Category:";
            // Removed: label5.Click += label5_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Location = new Point(294, 275);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.FlatStyle = FlatStyle.Popup;
            btnOk.Location = new Point(184, 275);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 6;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // comboBoxAuthors
            // 
            comboBoxAuthors.FormattingEnabled = true;
            comboBoxAuthors.Location = new Point(12, 198);
            comboBoxAuthors.Name = "comboBoxAuthors";
            comboBoxAuthors.Size = new Size(260, 23);
            comboBoxAuthors.TabIndex = 10;
            // 
            // btnAddAuthor
            // 
            btnAddAuthor.FlatStyle = FlatStyle.Popup;
            btnAddAuthor.Location = new Point(278, 198);
            btnAddAuthor.Name = "btnAddAuthor";
            btnAddAuthor.Size = new Size(91, 23);
            btnAddAuthor.TabIndex = 11;
            btnAddAuthor.Text = "Add Author";
            btnAddAuthor.UseVisualStyleBackColor = true;
            btnAddAuthor.Click += btnAddAuthor_Click;
            // 
            // comboBoxPublishers
            // 
            comboBoxPublishers.FormattingEnabled = true;
            comboBoxPublishers.Location = new Point(12, 144);
            comboBoxPublishers.Name = "comboBoxPublishers";
            comboBoxPublishers.Size = new Size(260, 23);
            comboBoxPublishers.TabIndex = 12;
            // 
            // btnAddPublisher
            // 
            btnAddPublisher.FlatStyle = FlatStyle.Popup;
            btnAddPublisher.Location = new Point(278, 144);
            btnAddPublisher.Name = "btnAddPublisher";
            btnAddPublisher.Size = new Size(91, 23);
            btnAddPublisher.TabIndex = 13;
            btnAddPublisher.Text = "Add Publisher";
            btnAddPublisher.UseVisualStyleBackColor = true;
            btnAddPublisher.Click += btnAddPublisher_Click;
            // 
            // NewBookForm
            // 
            AccessibleRole = AccessibleRole.TitleBar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(384, 310);
            Controls.Add(btnAddPublisher);
            Controls.Add(comboBoxPublishers);
            Controls.Add(btnAddAuthor);
            Controls.Add(comboBoxAuthors);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCategory);
            Controls.Add(txtIsbn);
            Controls.Add(txtTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "NewBookForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New book";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtIsbn;
        private TextBox txtCategory;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnCancel;
        private Button btnOk;
        private ComboBox comboBoxAuthors;
        private Button btnAddAuthor;
        private ComboBox comboBoxPublishers;
        private Button btnAddPublisher;
    }
}