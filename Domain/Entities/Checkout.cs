using Domain.Entities;

public class Checkout
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public string CustomerId { get; set; } // Change from int to string
    public ApplicationUser Customer { get; set; }
    public DateTime CheckedOutAt { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsReturned { get; set; }
}