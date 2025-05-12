using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp1.Classes
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Ім'я користувача обов'язкове")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Ім'я користувача має бути від 3 до 20 символів")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Пароль обов'язковий")]
        public string HashedPassword { get; set; }
        [Required(ErrorMessage = "Роль обов'язкова")]
        public string Role { get; set; }
        public List<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();

        public override void DisplayInfo()
        {
            Console.WriteLine($"User: {Username}, Role: {Role}");
        }
    }
}
