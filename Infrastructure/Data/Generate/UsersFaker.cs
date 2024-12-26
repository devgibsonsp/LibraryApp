using Bogus;
using System.Collections.Generic;
using Domain.Entities;
using Domain.ValueObjects;

namespace Infrastructure.Data.Generate
{
    public static class UserFaker
    {
        public static List<User> GenerateUsers(int count)
        {
            var userFaker = new Faker<User>()
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.PasswordHash, f => f.Internet.Password(8)) // Simulated hashed password
                .RuleFor(u => u.Role, f => f.PickRandom<UserRole>()) // Assign random role (Librarian/Customer)
                .RuleFor(u => u.Reviews, f => new List<Review>()) // Initialize empty reviews collection
                .RuleFor(u => u.Checkouts, f => new List<Checkout>()); // Initialize empty checkouts collection

            return userFaker.Generate(count);
        }
    }
}