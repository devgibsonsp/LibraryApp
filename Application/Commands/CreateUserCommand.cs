using MediatR;

namespace Application.Commands
{
    public class CreateUserCommand : IRequest<int> // Returns the new user's ID
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Hashing will occur before saving
        public string Role { get; set; }    // "Librarian" or "Customer"
    }
}