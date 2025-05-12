namespace BookApp1.Classes {
    public class BorrowedBook : BaseEntity {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }

        public override void DisplayInfo() {
            Console.WriteLine($"BorrowedBook: {Title}, Category: {Category}");
        }
    }
}