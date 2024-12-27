using Bogus;
using Domain.Entities;

namespace Infrastructure.Data.Generate
{
    public static class ReviewFaker
    {
        public static List<Review> GenerateReviews(int count, List<Book> books, List<User> users)
        {
            var reviewFaker = new Faker<Review>()
                .RuleFor(r => r.BookId, f => f.PickRandom(books).Id) // Pick a random BookId
                .RuleFor(r => r.Book, (f, r) => books.Find(b => b.Id == r.BookId)) // Assign the corresponding Book
                .RuleFor(r => r.CustomerId, f => f.PickRandom(users).Id) // Pick a random UserId
                .RuleFor(r => r.Customer, (f, r) => users.Find(u => u.Id == r.CustomerId)) // Assign the corresponding User
                .RuleFor(r => r.Message, f => f.Lorem.Sentences(2)) // Generate random review message
                .RuleFor(r => r.Rating, f => f.Random.Int(1, 5)) // Random rating between 1 and 5
                .RuleFor(r => r.CreatedAt, f => f.Date.Past(1)); // Random creation date in the past year

            return reviewFaker.Generate(count);
        }
    }
}