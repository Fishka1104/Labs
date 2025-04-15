using BookApp1.Classes.BookApp1.Classes;

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
            var userStorage = new JsonStorage<User>("users.json");
            var userRepository = new UserRepository(userStorage);

            // Створення та показ форми входу
            Application.Run(new LogIn(userRepository));
        }
    }
}