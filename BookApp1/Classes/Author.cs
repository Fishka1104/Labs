using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookApp1.Classes {
    public class Author : BaseEntity {
        [Required(ErrorMessage = "Назва автора обов'язкова")]
        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? Nationality { get; set; }
        public List<string> Genres { get; set; } = new List<string>();

        public override void DisplayInfo()
        {
            Console.WriteLine($"Author: {Name}, Birth: {BirthDate}, Death: {DeathDate}, Nationality: {Nationality}, Genres: {string.Join(", ", Genres)}");
        }
    }
}