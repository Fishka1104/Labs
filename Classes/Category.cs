using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp1.Classes {
    public class Category : BaseEntity {
        [Required(ErrorMessage = "Назва категорії обов'язкова")]
        public string Name { get; set; }

        public override void DisplayInfo() {
            Console.WriteLine($"Category: {Name}");
        }
    }
}