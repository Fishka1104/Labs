namespace BookApp1 {
    partial class EditBookForm {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBookForm));
            btnOk = new Button();
            btnCancel = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtCategory = new TextBox();
            txtIsbn = new TextBox();
            txtTitle = new TextBox();
            comboBoxAuthors = new ComboBox();
            btnAddAuthor = new Button();
            comboBoxPublishers = new ComboBox();
            btnAddPublisher = new Button();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.FlatStyle = FlatStyle.Popup;
            btnOk.Location = new Point(197, 296);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 6;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Location = new Point(294, 296);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 232);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 21;
            label5.Text = "Category:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 174);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 20;
            label4.Text = "Author:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 120);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 19;
            label3.Text = "Publisher:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 65);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 18;
            label2.Text = "ISBN:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 17;
            label1.Text = "Title:";
            // 
            // txtCategory
            // 
            txtCategory.BorderStyle = BorderStyle.FixedSingle;
            txtCategory.Location = new Point(12, 250);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(357, 23);
            txtCategory.TabIndex = 5;
            // 
            // txtIsbn
            // 
            txtIsbn.BorderStyle = BorderStyle.FixedSingle;
            txtIsbn.Location = new Point(12, 83);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(357, 23);
            txtIsbn.TabIndex = 2;
            // 
            // txtTitle
            // 
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Location = new Point(12, 30);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(357, 23);
            txtTitle.TabIndex = 1;
            // 
            // comboBoxAuthors
            // 
            comboBoxAuthors.FormattingEnabled = true;
            comboBoxAuthors.Location = new Point(12, 192);
            comboBoxAuthors.Name = "comboBoxAuthors";
            comboBoxAuthors.Size = new Size(260, 23);
            comboBoxAuthors.TabIndex = 22;
            // 
            // btnAddAuthor
            // 
            btnAddAuthor.FlatStyle = FlatStyle.Popup;
            btnAddAuthor.Location = new Point(278, 192);
            btnAddAuthor.Name = "btnAddAuthor";
            btnAddAuthor.Size = new Size(91, 23);
            btnAddAuthor.TabIndex = 23;
            btnAddAuthor.Text = "Add Author";
            btnAddAuthor.UseVisualStyleBackColor = true;
            btnAddAuthor.Click += btnAddAuthor_Click;
            // 
            // comboBoxPublishers
            // 
            comboBoxPublishers.FormattingEnabled = true;
            comboBoxPublishers.Location = new Point(12, 138);
            comboBoxPublishers.Name = "comboBoxPublishers";
            comboBoxPublishers.Size = new Size(260, 23);
            comboBoxPublishers.TabIndex = 24;
            // 
            // btnAddPublisher
            // 
            btnAddPublisher.FlatStyle = FlatStyle.Popup;
            btnAddPublisher.Location = new Point(278, 138);
            btnAddPublisher.Name = "btnAddPublisher";
            btnAddPublisher.Size = new Size(91, 23);
            btnAddPublisher.TabIndex = 25;
            btnAddPublisher.Text = "Add Publisher";
            btnAddPublisher.UseVisualStyleBackColor = true;
            btnAddPublisher.Click += btnAddPublisher_Click;
            // 
            // EditBookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(385, 331);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "EditBookForm";
            Text = "Edit Book";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOk;
        private Button btnCancel;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtCategory;
        private TextBox txtIsbn;
        private TextBox txtTitle;
        private ComboBox comboBoxAuthors;
        private Button btnAddAuthor;
        private ComboBox comboBoxPublishers;
        private Button btnAddPublisher;
    }
}