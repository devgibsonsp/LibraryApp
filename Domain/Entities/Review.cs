using Domain.Entities;

public class Review
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public string CustomerId { get; set; } // Change from int to string
    public ApplicationUser Customer { get; set; }
    public string Message { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
}