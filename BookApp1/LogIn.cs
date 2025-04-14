using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookApp1;
using BookApp1.Classes;


namespace BookApp1
{
    public partial class LogIn : Form
    {


        public string UserRole { get; private set; }

        public LogIn()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            listBoxUsers.DataSource = null; 
            listBoxUsers.DataSource = UserRepository.GetUsers();
            listBoxUsers.DisplayMember = "Username";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBoxName.Clear();
            textBoxPassword.Clear();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItem is User selectedUser)
            {
                var result = MessageBox.Show($"Ви впевнені, що бажаєте видалити користувача {selectedUser.Username}?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    UserRepository.DeleteUser(selectedUser.Username);
                    LoadUsers();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть користувача для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxName.Text;
            string password = textBoxPassword.Text;

            // Перевірка користувача в репозиторії
            var user = UserRepository.GetUser(username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.HashedPassword))
            {
                UserRole = user.Role;
            }
            else
            {
                MessageBox.Show("Неправильне ім'я користувача або пароль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MainForm mainForm = new MainForm(UserRole);
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        
    }

}