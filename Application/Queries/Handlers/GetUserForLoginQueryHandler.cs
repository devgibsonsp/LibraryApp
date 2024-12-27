using Application.Queries;
using Application.Responses;
using AutoMapper;
using Domain.Contracts;
using MediatR;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Users
{
    public class GetUserForLoginQueryHandler : IRequestHandler<GetUserForLoginQuery, UserLoginResponse>
    {
        private readonly ILibraryReadRepository _libraryReadRepository;
        private readonly IMapper _mapper;

        public GetUserForLoginQueryHandler(ILibraryReadRepository libraryReadRepository, IMapper mapper)
        {
            _libraryReadRepository = libraryReadRepository;
            _mapper = mapper;
        }

        public async Task<UserLoginResponse> Handle(GetUserForLoginQuery request, CancellationToken cancellationToken)
        {
            // Fetch the user by email
            var user = await _libraryReadRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            // Verify the password
            using var sha256 = SHA256.Create();
            var hashedPassword = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(request.Password)));

            if (user.PasswordHash != hashedPassword)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            // Map the user to the response object
            return _mapper.Map<UserLoginResponse>(user);
        }
    }
}