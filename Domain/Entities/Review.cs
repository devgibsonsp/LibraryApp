namespace Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int CustomerId { get; set; }
        public User Customer { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; } // 1 to 5 stars
        public DateTime CreatedAt { get; set; }
    }
}
