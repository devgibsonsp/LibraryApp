using Bogus;
using System;
using System.Collections.Generic;
using Domain.Definitions;

namespace Infrastructure.Data
{

    public static class BookFaker
    {
        
        public static List<Book> GenerateBooks(int count)
        {
            var bookFaker = new Faker<Book>()
                .RuleFor(b => b.Title, f => f.Lorem.Sentence(3))
                .RuleFor(b => b.Author, f => f.Name.FullName())
                .RuleFor(b => b.Description, f => f.Lorem.Paragraph())
                .RuleFor(b => b.CoverImage, f => f.Image.PicsumUrl())
                .RuleFor(b => b.Publisher, f => f.Company.CompanyName())
                .RuleFor(b => b.PublicationDate, f => f.Date.Past(20))
                .RuleFor(b => b.Category, f => f.Commerce.Categories(1)[0])
                .RuleFor(b => b.ISBN, f => f.Commerce.Ean13())
                .RuleFor(b => b.PageCount, f => f.Random.Int(100, 500))
                .RuleFor(b => b.IsAvailable, f => f.Random.Bool())
                .RuleFor(b => b.AverageRating, f => f.Random.Double(1, 5));

            return bookFaker.Generate(count);
        }
        
    }
}