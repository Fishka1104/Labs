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

namespace BookApp1
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
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
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string confirmPassword = textBoxConfirmPassword.Text;
            string role = comboBoxRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Будь ласка, виберіть роль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Паролі не співпадають", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Хешування пароля
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // Додавання користувача до репозиторію
            UserRepository.AddUser(username, hashedPassword, role);

            MessageBox.Show("Реєстрація успішна", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Повернення до форми входу
            this.Close();
        }
    }
}
