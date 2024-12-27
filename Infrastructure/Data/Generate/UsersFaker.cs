using Bogus;
using System.Collections.Generic;
using Domain.Entities;

namespace Infrastructure.Data.Generate
{
    public static class UserFaker
    {
        public static List<ApplicationUser> GenerateUsers(int count)
        {
            var userFaker = new Faker<ApplicationUser>()
                .RuleFor(u => u.UserName, f => f.Internet.UserName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.PasswordHash, f => f.Internet.Password(8)) // Simulated hashed password
                .RuleFor(u => u.Reviews, f => new List<Review>()) // Initialize empty reviews collection
                .RuleFor(u => u.Checkouts, f => new List<Checkout>()); // Initialize empty checkouts collection

            return userFaker.Generate(count);
        }
    }
}