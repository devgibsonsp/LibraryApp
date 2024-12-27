using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LibraryWriteRepository : ILibraryWriteRepository
    {
        private readonly AppDbContext _dbContext;

        public LibraryWriteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddUserAsync(ApplicationUser user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user.Id; // Return the string ID of the newly created user
        }

        public async Task SoftDeleteBookAsync(int bookId)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null) throw new Exception("Book not found");

            book.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books
                .Where(b => !b.IsDeleted) // Exclude soft-deleted books
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateBookAsync(Book book)
        {
            // Mark the book entity as modified
            _dbContext.Books.Update(book);

            // Save changes to the database
            await _dbContext.SaveChangesAsync();
        }
    }
}