using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ILibraryWriteRepository
    {
        Task<int> AddUserAsync(User user); // Returns the user's ID

        Task SoftDeleteBookAsync(int bookId);

        Task UpdateBookAsync(Book book);

    }
}