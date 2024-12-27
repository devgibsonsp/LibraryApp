using Application.Responses;
using AutoMapper;
using Domain.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserResponse>>
    {
        private readonly ILibraryReadRepository _libraryReadRepository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(ILibraryReadRepository libraryReadRepository, IMapper mapper)
        {
            _libraryReadRepository = libraryReadRepository;
            _mapper = mapper;
        }

        public async Task<List<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            // Fetch domain entities from the repository
            var users = await _libraryReadRepository.GetAllUsersAsync();

            // Map domain entities to response models
            return _mapper.Map<List<UserResponse>>(users);
        }
    }
}