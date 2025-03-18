using System;

namespace BookApp1.Classes {
    public class Publisher : BaseEntity {
        public string Name { get; set; }
        public string Headquarters { get; set; }
        public string Address { get; set; }
        public DateTime? Founded { get; set; }
        public string CeoFounder { get; set; }

        public override void DisplayInfo() {
            Console.WriteLine($"Publisher: {Name}, Headquarters: {Headquarters}, Address: {Address}, Founded: {Founded?.ToShortDateString() ?? "Unknown"}, CEO/Founder: {CeoFounder}");
        }
    }
}