using System;
using System.Windows.Forms;
using BookApp1.Classes;

namespace BookApp1.Classes
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Створення зберігання для користувачів
            var userStorage = new SQLiteStorage<User>("Users"); // Переконайтеся, що ім’я таблиці "Users"
            var userRepository = new UserRepository(userStorage);

            // Створення та показ форми входу
            Application.Run(new LogIn(userRepository));
        }
    }
}