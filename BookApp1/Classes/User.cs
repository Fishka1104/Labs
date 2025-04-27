using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp1.Classes
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string Role { get; set; }
        public List<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();

        public override void DisplayInfo()
        {
            Console.WriteLine($"User: {Username}, Role: {Role}");
        }
    }
}
