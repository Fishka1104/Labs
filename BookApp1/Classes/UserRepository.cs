using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace BookApp1.Classes
{
    public static class UserRepository
    {
        private static readonly string filePath = "users.json";

        public static List<User> GetUsers()
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        public static void AddUser(string username, string hashedPassword, string role)
        {
            var users = GetUsers();
            users.Add(new User { Username = username, HashedPassword = hashedPassword, Role = role });
            SaveUsers(users);
        }

        public static User GetUser(string username)
        {
            return GetUsers().FirstOrDefault(u => u.Username == username);
        }

        private static void SaveUsers(List<User> users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }

}
