using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookApp1.Classes;
using BookApp1.Classes.BookApp1.Classes;

namespace BookApp1
{
    public partial class RegisterForm : Form
    {
        private readonly UserRepository _userRepository;

        public RegisterForm(UserRepository userRepository)
        {
            InitializeComponent();
            _userRepository = userRepository;
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            comboBoxRole.Items.Add("admin");
            comboBoxRole.Items.Add("user");
            comboBoxRole.SelectedIndex = 1;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text;
            string confirmPassword = textBoxConfirmPassword.Text;
            string role = comboBoxRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Будь ласка, виберіть роль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Будь ласка, введіть ім'я користувача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Будь ласка, введіть пароль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Паролі не співпадають.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Перевірка чи існує такий юзер
            var existingUser = _userRepository.GetUser(username);
            if (existingUser != null)
            {
                MessageBox.Show("Користувач з таким ім'ям вже існує. Виберіть інше ім'я.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = new User
            {
                Username = username,
                HashedPassword = BCrypt.Net.BCrypt.HashPassword(password),
                Role = role
            };

            var validationResults = ValidationService.Validate(user);

            if (validationResults.Any())
            {
                MessageBox.Show(string.Join("\n", validationResults.Select(r => r.ErrorMessage)), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _userRepository.AddUser(user.Username, user.HashedPassword, user.Role);

            MessageBox.Show("Реєстрація успішна", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }

}
