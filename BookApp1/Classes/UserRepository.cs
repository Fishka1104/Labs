using System;
using System.Collections.Generic;
using System.Linq;

namespace BookApp1.Classes {
    public class UserRepository : GenericRepository<User>, IUserRepository {
        public UserRepository(IDataStorage<User> storage) : base(storage) {
        }

        public List<User> GetUsers() {
            return base.GetAll();
        }

        public void AddUser(string username, string hashedPassword, string role) {
            var user = new User { Username = username, HashedPassword = hashedPassword, Role = role };
            base.Add(user);
            Console.WriteLine($"User added: {username}, ID: {user.Id}");
        }

        public User? GetUser(string username) {
            var user = base.GetAll().FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"GetUser called for {username}, Found: {(user != null ? user.Username : "null")}");
            return user;
        }

        public void DeleteUser(string username) {
            var user = GetUser(username);
            if (user != null) {
                base.Delete(user.Id);
            }
        }
    }
}