namespace Domain.Entities
{
    public class Checkout
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int CustomerId { get; set; }
        public User Customer { get; set; }
        public DateTime CheckedOutAt { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
