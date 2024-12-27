using MediatR;

namespace Application.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}