using System;
using System.Text.Json.Serialization;

namespace BookApp1.Classes {
    public class Book : BaseEntity {
        public string Title { get; set; }
        public Isbn Isbn { get; set; }

        [JsonIgnore]
        public Publisher Publisher { get; set; }

        [JsonPropertyName("PublisherId")]
        public int PublisherId { get; set; }

        [JsonIgnore]
        public Author Author { get; set; }

        [JsonPropertyName("AuthorId")]
        public int AuthorId { get; set; }

        public Category Category { get; set; }

        public override void DisplayInfo() {
            Console.WriteLine($"Book: {Title}, ISBN: {Isbn.Code}, Author: {Author?.Name ?? "Unknown"}, Publisher: {Publisher?.Name ?? "Unknown"}, Category: {Category.Name}");
        }
    }
}