using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LibraryReadRepository : ILibraryReadRepository
    {
        private readonly AppDbContext _dbContext;

        public LibraryReadRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books
                .Where(b => !b.IsDeleted) // Exclude deleted books
                .Include(b => b.Reviews) // Include related reviews
                .ThenInclude(r => r.Customer) // Include customer details for reviews
                .ToListAsync();
        }

        public async Task<List<Book>> SearchBooksByTitleAsync(string title)
        {
            return await _dbContext.Books
                .Where(b => !b.IsDeleted && EF.Functions.Like(b.Title, $"%{title}%")) // Partial match, case-insensitive
                .Include(b => b.Reviews) // Include reviews
                .ThenInclude(r => r.Customer) // Include customer for reviews
                .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books
                .Where(b => !b.IsDeleted) // Exclude soft-deleted books
                .Include(b => b.Reviews) // Include reviews
                .ThenInclude(r => r.Customer) // Include customer details for reviews
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        /*
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Checkout>> GetCheckoutsByUserIdAsync(int userId)
        {
            return await _dbContext.Checkouts
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }
        
        public async Task<List<Review>> GetReviewsByBookIdAsync(int bookId)
        {
            return await _dbContext.Reviews
                .Where(r => r.BookId == bookId)
                .ToListAsync();
        }
        */
    }
}