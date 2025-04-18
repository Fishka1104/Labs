﻿using System;
using System.Collections.Generic;

namespace BookApp1.Classes {
    public class Author : BaseEntity {
        public string Name { get; set; } // Renamed from FullName
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string Nationality { get; set; }
        public List<string> Genres { get; set; } = new List<string>();

        public override void DisplayInfo() {
            string lifeSpan = (BirthDate.HasValue ? BirthDate.Value.ToShortDateString() : "Unknown") +
                             " - " +
                             (DeathDate.HasValue ? DeathDate.Value.ToShortDateString() : "Present");
            Console.WriteLine($"Author: {Name}, Life: {lifeSpan}, Nationality: {Nationality}, Genres: {string.Join(", ", Genres)}");
        }
    }
}