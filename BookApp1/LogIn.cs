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
using BookApp1.Classes.BookApp1.Classes;


namespace BookApp1
{
    public partial class LogIn : Form
    {
        private readonly UserRepository _userRepository;
        public string UserRole { get; private set; }

        public LogIn(UserRepository userRepository)
        {
            InitializeComponent();
            _userRepository = userRepository;
            LoadUsers();
        }

        private void LoadUsers()
        {
            listBoxUsers.DataSource = null;
            listBoxUsers.DataSource = _userRepository.GetUsers();
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
                    _userRepository.DeleteUser(selectedUser.Username);
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
            var user = _userRepository.GetUser(username); // Використовуйте екземпляр _userRepository
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.HashedPassword))
            {
                UserRole = user.Role;
                MainForm mainForm = new MainForm(UserRole, user);
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильне ім'я користувача або пароль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(_userRepository);
            registerForm.ShowDialog();
        }
    }

}