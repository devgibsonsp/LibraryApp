using MediatR;
using Application.Responses;

namespace Application.Queries
{
    public class GetUsersQuery : IRequest<List<UserResponse>>
    {
    }
}
