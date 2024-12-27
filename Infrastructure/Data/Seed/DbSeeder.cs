using Microsoft.EntityFrameworkCore;
using System.Linq;
using Domain.Entities;
using Infrastructure.Data.Generate;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data.Seed
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.Migrate();

            // Step 1: Seed roles
            var roles = new[] { "Librarian", "Customer" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Step 2: Seed data if tables are empty
            if (!context.Users.Any() && !context.Books.Any() && !context.Checkouts.Any())
            {
                var books = BookFaker.GenerateBooks(20);
                var users = UserFaker.GenerateUsers(10);

                foreach (var user in users)
                {
                    // Create user via UserManager
                    var result = await userManager.CreateAsync(user, "Password123!");
                    if (result.Succeeded)
                    {
                        // Assign a random role
                        var assignedRole = new Random().Next(0, 2) == 0 ? "Librarian" : "Customer";
                        await userManager.AddToRoleAsync(user, assignedRole);
                    }
                    else
                    {
                        Console.WriteLine($"Failed to create user {user.Email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }

                context.Books.AddRange(books);
                await context.SaveChangesAsync(); // Save books before generating reviews and checkouts

                var reviews = ReviewFaker.GenerateReviews(50, books, users);
                var checkouts = CheckoutFaker.GenerateCheckouts(30, books, users);
                context.Reviews.AddRange(reviews);
                context.Checkouts.AddRange(checkouts);
                await context.SaveChangesAsync();

                Console.WriteLine("Database seeded successfully.");
            }
            else
            {
                Console.WriteLine("Database already contains data.");
            }
        }
    }
}
