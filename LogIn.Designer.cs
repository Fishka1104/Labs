namespace BookApp1
{
    partial class LogIn
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
            label1 = new Label();
            label2 = new Label();
            textBoxName = new TextBox();
            textBoxPassword = new TextBox();
            btnLogin = new Button();
            btnReset = new Button();
            btnExit = new Button();
            btnGoToRegister = new Button();
            listBoxUsers = new ListBox();
            btnDeleteUser = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 45);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "User name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 99);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // textBoxName
            // 
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            textBoxName.Location = new Point(113, 43);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(167, 23);
            textBoxName.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.Location = new Point(113, 97);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(167, 23);
            textBoxPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Location = new Point(47, 159);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnReset
            // 
            btnReset.FlatStyle = FlatStyle.Popup;
            btnReset.Location = new Point(180, 159);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 23);
            btnReset.TabIndex = 5;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnExit
            // 
            btnExit.FlatStyle = FlatStyle.Popup;
            btnExit.Location = new Point(180, 213);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 23);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnGoToRegister
            // 
            btnGoToRegister.FlatStyle = FlatStyle.Popup;
            btnGoToRegister.Location = new Point(47, 213);
            btnGoToRegister.Name = "btnGoToRegister";
            btnGoToRegister.Size = new Size(100, 23);
            btnGoToRegister.TabIndex = 7;
            btnGoToRegister.Text = "Register";
            btnGoToRegister.UseVisualStyleBackColor = true;
            btnGoToRegister.Click += btnGoToRegister_Click;
            // 
            // listBoxUsers
            // 
            listBoxUsers.FormattingEnabled = true;
            listBoxUsers.ItemHeight = 15;
            listBoxUsers.Location = new Point(320, 43);
            listBoxUsers.Name = "listBoxUsers";
            listBoxUsers.Size = new Size(187, 139);
            listBoxUsers.TabIndex = 8;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.FlatStyle = FlatStyle.Popup;
            btnDeleteUser.Location = new Point(361, 213);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(100, 23);
            btnDeleteUser.TabIndex = 9;
            btnDeleteUser.Text = "Delete";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 275);
            Controls.Add(btnDeleteUser);
            Controls.Add(listBoxUsers);
            Controls.Add(btnGoToRegister);
            Controls.Add(btnExit);
            Controls.Add(btnReset);
            Controls.Add(btnLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LogIn";
            Text = "LogIn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxName;
        private TextBox textBoxPassword;
        private Button btnLogin;
        private Button btnReset;
        private Button btnExit;
        private Button btnGoToRegister;
        private ListBox listBoxUsers;
        private Button btnDeleteUser;
    }
}