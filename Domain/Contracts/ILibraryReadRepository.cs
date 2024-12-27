using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ILibraryReadRepository
    {
        Task<List<ApplicationUser>> GetAllUsersAsync();

        Task<List<Book>> GetAllBooksAsync();

        Task<Book> GetBookByIdAsync(int id);

        Task<List<Book>> SearchBooksByTitleAsync(string title);

        Task<ApplicationUser> GetUserByEmailAsync(string email);
        /*
        Task<User> GetUserByIdAsync(int id);
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<List<Checkout>> GetCheckoutsByUserIdAsync(int userId);
        Task<List<Review>> GetReviewsByBookIdAsync(int bookId);
        */
    }
}