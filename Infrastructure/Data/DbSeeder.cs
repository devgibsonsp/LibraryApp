using Microsoft.EntityFrameworkCore;
using System.Linq;
using Domain.Definitions;

namespace Infrastructure.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // TODO
            // CLEAN THIS UP

            // Ensure the database is created and up to date
            context.Database.Migrate();

            if (!context.Books.Any())
            {
                var books = BookFaker.GenerateBooks(20); // Generate 20 books
                context.Books.AddRange(books);
                context.SaveChanges();
                Console.WriteLine("Database seeded successfully.");
            }
            else
            {
                Console.WriteLine("Books table already contains data.");
            }
        }
    }
}