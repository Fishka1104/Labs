namespace BookApp1 {
    partial class MainForm {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            dataGridViewBooks = new DataGridView();
            btnNewForm = new Button();
            btnOpenEditForm = new Button();
            btnBookDelete = new Button();
            textBoxFilter = new TextBox();
            btnManageAuthors = new Button();
            btnManagePublishers = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(34, 53);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.Size = new Size(643, 318);
            dataGridViewBooks.TabIndex = 0;
            // 
            // btnNewForm
            // 
            btnNewForm.FlatStyle = FlatStyle.Popup;
            btnNewForm.Location = new Point(411, 397);
            btnNewForm.Name = "btnNewForm";
            btnNewForm.Size = new Size(75, 23);
            btnNewForm.TabIndex = 1;
            btnNewForm.Text = "New";
            btnNewForm.UseVisualStyleBackColor = true;
            btnNewForm.Click += btnNewForm_Click;
            // 
            // btnOpenEditForm
            // 
            btnOpenEditForm.FlatStyle = FlatStyle.Popup;
            btnOpenEditForm.Location = new Point(509, 397);
            btnOpenEditForm.Name = "btnOpenEditForm";
            btnOpenEditForm.Size = new Size(75, 23);
            btnOpenEditForm.TabIndex = 2;
            btnOpenEditForm.Text = "Edit";
            btnOpenEditForm.UseVisualStyleBackColor = true;
            btnOpenEditForm.Click += btnOpenEditForm_Click;
            // 
            // btnBookDelete
            // 
            btnBookDelete.FlatStyle = FlatStyle.Popup;
            btnBookDelete.Location = new Point(602, 397);
            btnBookDelete.Name = "btnBookDelete";
            btnBookDelete.Size = new Size(75, 23);
            btnBookDelete.TabIndex = 3;
            btnBookDelete.Text = "Delete";
            btnBookDelete.UseVisualStyleBackColor = true;
            btnBookDelete.Click += btnBookDelete_Click; // Kept as is, assuming it exists
            // 
            // textBoxFilter
            // 
            textBoxFilter.BorderStyle = BorderStyle.FixedSingle;
            textBoxFilter.Location = new Point(34, 12);
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new Size(194, 23);
            textBoxFilter.TabIndex = 4;
            textBoxFilter.TextChanged += textBoxFilter_TextChanged;
            // 
            // btnManageAuthors
            // 
            btnManageAuthors.FlatStyle = FlatStyle.Popup;
            btnManageAuthors.Location = new Point(286, 397);
            btnManageAuthors.Name = "btnManageAuthors";
            btnManageAuthors.Size = new Size(107, 23);
            btnManageAuthors.TabIndex = 5;
            btnManageAuthors.Text = "Manage Authors";
            btnManageAuthors.UseVisualStyleBackColor = true;
            btnManageAuthors.Click += btnManageAuthors_Click;
            // 
            // btnManagePublishers
            // 
            btnManagePublishers.FlatStyle = FlatStyle.Popup;
            btnManagePublishers.Location = new Point(148, 397);
            btnManagePublishers.Name = "btnManagePublishers";
            btnManagePublishers.Size = new Size(132, 23);
            btnManagePublishers.TabIndex = 6;
            btnManagePublishers.Text = "Manage Publishers";
            btnManagePublishers.UseVisualStyleBackColor = true;
            btnManagePublishers.Click += btnManagePublishers_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 450);
            Controls.Add(btnManagePublishers);
            Controls.Add(btnManageAuthors);
            Controls.Add(textBoxFilter);
            Controls.Add(btnBookDelete);
            Controls.Add(btnOpenEditForm);
            Controls.Add(btnNewForm);
            Controls.Add(dataGridViewBooks);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "MainForm";
            Text = "Library system";
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewBooks;
        private Button btnNewForm;
        private Button btnOpenEditForm;
        private Button btnBookDelete;
        private TextBox textBoxFilter;
        private Button btnManageAuthors;
        private Button btnManagePublishers;
    }
}