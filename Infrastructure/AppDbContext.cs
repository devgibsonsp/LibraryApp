using Microsoft.EntityFrameworkCore;
using Domain.Definitions;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}