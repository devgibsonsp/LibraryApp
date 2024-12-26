using Microsoft.EntityFrameworkCore;
using System.Linq;
using Domain.Entities;
using Infrastructure.Data.Generate;

namespace Infrastructure.Data.Seed
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate();

            if (!context.Users.Any() && !context.Books.Any() && !context.Checkouts.Any())
            {
                var books = BookFaker.GenerateBooks(20);
                var users = UserFaker.GenerateUsers(10);
                context.Books.AddRange(books);
                context.Users.AddRange(users);
                context.SaveChanges(); // Save books and users before generating reviews and checkouts

                var reviews = ReviewFaker.GenerateReviews(50, books, users);
                var checkouts = CheckoutFaker.GenerateCheckouts(30, books, users);
                context.Reviews.AddRange(reviews);
                context.Checkouts.AddRange(checkouts);
                context.SaveChanges();

                Console.WriteLine("Database seeded successfully.");
            }
            else
            {
                Console.WriteLine("Database already contains data.");
            }
        }
    }
}