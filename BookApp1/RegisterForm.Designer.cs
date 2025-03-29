namespace BookApp1
{
    partial class RegisterForm
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
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            textBoxConfirmPassword = new TextBox();
            btnRegister = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBoxRole = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // textBoxUsername
            // 
            textBoxUsername.BorderStyle = BorderStyle.FixedSingle;
            textBoxUsername.Location = new Point(161, 25);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(169, 23);
            textBoxUsername.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.Location = new Point(161, 67);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(169, 23);
            textBoxPassword.TabIndex = 1;
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxConfirmPassword.Location = new Point(161, 109);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new Size(169, 23);
            textBoxConfirmPassword.TabIndex = 2;
            // 
            // btnRegister
            // 
            btnRegister.FlatStyle = FlatStyle.Popup;
            btnRegister.Location = new Point(161, 205);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(169, 23);
            btnRegister.TabIndex = 3;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 27);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 4;
            label1.Text = "User name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 69);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 5;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 111);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 6;
            label3.Text = "Confirm password:";
            // 
            // comboBoxRole
            // 
            comboBoxRole.FormattingEnabled = true;
            comboBoxRole.Location = new Point(161, 149);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(169, 23);
            comboBoxRole.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(77, 152);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 8;
            label4.Text = "Account role:";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 260);
            Controls.Add(label4);
            Controls.Add(comboBoxRole);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRegister);
            Controls.Add(textBoxConfirmPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private TextBox textBoxConfirmPassword;
        private Button btnRegister;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxRole;
        private Label label4;
    }
}