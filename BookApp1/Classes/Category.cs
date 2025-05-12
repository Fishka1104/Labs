using System.ComponentModel.DataAnnotations;

namespace BookApp1.Classes {
    public class Category : BaseEntity {
        [Required(ErrorMessage = "Назва категорії обов'язкова")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Назва категорії має бути від 1 до 100 символів")]
        public string Name { get; set; }

        public Category() { }

        public override void DisplayInfo() {
            Console.WriteLine($"Category: {Name}");
        }
    }
}