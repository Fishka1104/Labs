namespace BookApp1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            dataGridViewBooks = new DataGridView();
            btnNewForm = new Button();
            btnOpenEditForm = new Button();
            btnBookDelete = new Button();
            textBoxFilter = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(34, 33);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.Size = new Size(643, 338);
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
            btnBookDelete.Click += btnBookDelete_Click;
            // 
            // textBoxFilter
            // 
            textBoxFilter.BorderStyle = BorderStyle.FixedSingle;
            textBoxFilter.Location = new Point(34, 397);
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new Size(194, 23);
            textBoxFilter.TabIndex = 4;
            textBoxFilter.TextChanged += textBoxFilter_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 450);
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
    }
}
