using Bogus;
using Domain.Entities;

public static class CheckoutFaker
{
    public static List<Checkout> GenerateCheckouts(int count, List<Book> books, List<ApplicationUser> users)
    {
        var checkoutFaker = new Faker<Checkout>()
            .RuleFor(c => c.BookId, f => f.PickRandom(books).Id) // Pick a random Book and use its Id
            .RuleFor(c => c.Book, (f, c) => books.Find(b => b.Id == c.BookId)) // Assign the corresponding Book
            .RuleFor(c => c.CustomerId, f => f.PickRandom(users).Id) // Pick a random string UserId
            .RuleFor(c => c.Customer, (f, c) => users.Find(u => u.Id == c.CustomerId)) // Assign the corresponding User
            .RuleFor(c => c.CheckedOutAt, f => f.Date.Past(1)) // Random date in the past year
            .RuleFor(c => c.DueDate, (f, c) => c.CheckedOutAt.AddDays(5)) // Due 5 days after CheckedOutAt
            .RuleFor(c => c.IsReturned, f => f.Random.Bool(0.5f)); // 50% chance of being returned

        return checkoutFaker.Generate(count);
    }
}