using Bogus;
using Domain.Entities;

public static class ReviewFaker
{
    public static List<Review> GenerateReviews(int count, List<Book> books, List<ApplicationUser> users)
    {
        var reviewFaker = new Faker<Review>()
            .RuleFor(r => r.BookId, f => f.PickRandom(books).Id)
            .RuleFor(r => r.Book, (f, r) => books.Find(b => b.Id == r.BookId))
            .RuleFor(r => r.CustomerId, f => f.PickRandom(users).Id)
            .RuleFor(r => r.Customer, (f, r) => users.Find(u => u.Id == r.CustomerId))
            .RuleFor(r => r.Message, f => f.Lorem.Sentences(2)) // Generate non-null random message
            .RuleFor(r => r.Rating, f => f.Random.Int(1, 5))
            .RuleFor(r => r.CreatedAt, f => f.Date.Past(1));

        return reviewFaker.Generate(count);
    }
}
