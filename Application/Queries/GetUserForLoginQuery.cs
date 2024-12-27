using MediatR;
using Application.Responses;

namespace Application.Queries
{
    public class GetUserForLoginQuery : IRequest<UserLoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}