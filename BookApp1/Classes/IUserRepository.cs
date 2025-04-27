using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp1.Classes
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        void AddUser(string username, string hashedPassword, string role);
        User? GetUser(string username);
    }
}
