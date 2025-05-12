using System.ComponentModel.DataAnnotations;

namespace BookApp1.Classes {
    public class Book : BaseEntity {
        [Required(ErrorMessage = "Назва книги обов'язкова")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN обов'язковий")]
        public Isbn Isbn { get; set; }

        [Required(ErrorMessage = "Автор обов'язковий")]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        [Required(ErrorMessage = "Видавництво обов'язкове")]
        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        [Required(ErrorMessage = "Категорія обов'язкова")]
        public Category Category { get; set; }

        public Book() {
            Isbn = new Isbn();
            Author = new Author();
            Publisher = new Publisher();
            Category = new Category();
        }

        public override void DisplayInfo() {
            Console.WriteLine($"Book: {Title}, ISBN: {Isbn?.Code}, Author: {Author?.Name}, Publisher: {Publisher?.Name}, Category: {Category?.Name}");
        }
    }
}