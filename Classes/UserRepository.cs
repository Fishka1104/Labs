using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace BookApp1.Classes
{
    using System.Collections.Generic;
    using System.Linq;

    namespace BookApp1.Classes
    {
        public class UserRepository : GenericRepository<User>, IUserRepository
        {
            public UserRepository(IDataStorage<User> storage) : base(storage)
            {
            }

            public List<User> GetUsers()
            {
                return base.GetAll();
            }

            public void AddUser(string username, string hashedPassword, string role)
            {
                var user = new User { Username = username, HashedPassword = hashedPassword, Role = role };
                base.Add(user);
            }

            public User? GetUser(string username)
            {
                return base.GetAll().FirstOrDefault(u => u.Username == username);
            }

            public void DeleteUser(string username)
            {
                var user = GetUser(username);
                if (user != null)
                {
                    base.Delete(user.Id);
                }
            }
        }
    }


}

