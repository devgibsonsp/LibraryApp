using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Checkout>()
                .HasOne(c => c.Book)
                .WithMany()
                .HasForeignKey(c => c.BookId);

            modelBuilder.Entity<Checkout>()
                .HasOne(c => c.Customer)
                .WithMany(u => u.Checkouts)
                .HasForeignKey(c => c.CustomerId);
        }
    }
}