using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BookApp1.Classes {
    public class Book : BaseEntity {
        [Required(ErrorMessage = "Назва книги обов'язкова")]
        public string Title { get; set; }
        [Required(ErrorMessage = "ISBN обов'язковий")]
        public Isbn Isbn { get; set; }

        [JsonIgnore]
        public Publisher Publisher { get; set; }

        [JsonPropertyName("PublisherId")]
        [Required(ErrorMessage = "Видавець обов'язковий")]
        public int PublisherId { get; set; }

        [JsonIgnore]
        public Author Author { get; set; }

        [JsonPropertyName("AuthorId")]
        [Required(ErrorMessage = "Автор обов'язковий")]
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Категорія обов'язкова")]
        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public override void DisplayInfo() {
            Console.WriteLine($"Book: {Title}, ISBN: {Isbn.Code}, Author: {Author?.Name ?? "Unknown"}, Publisher: {Publisher?.Name ?? "Unknown"}, Category: {Category.Name}");
        }
    }
}