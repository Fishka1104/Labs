using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace BookApp1.Classes
{
    public static class UserRepository 
    {
        private static readonly JsonStorage<User> _storage = new JsonStorage<User>("users.json");

        public static List<User> GetUsers()
        {
            return _storage.GetAll();
        }

        public static void AddUser(string username, string hashedPassword, string role)
        {
            var user = new User { Username = username, HashedPassword = hashedPassword, Role = role };
            _storage.Add(user);
            _storage.Save();
        }

        public static User GetUser(string username)
        {
            return _storage.GetAll().FirstOrDefault(u => u.Username == username);
        }

        public static void DeleteUser(string username)
        {
            var user = GetUser(username);
            if (user != null)
            {
                _storage.Delete(user.Id);
                _storage.Save();
            }
        }
    }

}
