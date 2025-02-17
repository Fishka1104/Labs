using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace BookApp1
{
    public partial class LogIn : Form
    {

        public string UserRole { get; private set; }

        public LogIn()
        {
            InitializeComponent();
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

      
               
            private void btnLogin_Click(object sender, EventArgs e)
            {
                string username = textBoxName.Text;
                string password = textBoxPassword.Text;

                if (username == "admin" && password == "admin")
                {
                    UserRole = "admin";
                }
                else if (username == "user" && password == "user")
                {
                    UserRole = "user";
                }
                else
                {
                    MessageBox.Show("Неправильне ім'я користувача або пароль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            //Якщо логін і пароль admin то UserRole = admin акщо логін і пароль user то UserRole = user інакше показує повідомлення про помилку не відкриваючи MainForm.

                MainForm mainForm = new MainForm(UserRole);
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
    }



}
    

