using Application.Queries;
using Application.Responses;
using AutoMapper;
using Domain.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookResponse>>
    {
        private readonly ILibraryReadRepository _libraryReadRepository;
        private readonly IMapper _mapper;

        public GetAllBooksQueryHandler(ILibraryReadRepository libraryReadRepository, IMapper mapper)
        {
            _libraryReadRepository = libraryReadRepository;
            _mapper = mapper;
        }

        public async Task<List<BookResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _libraryReadRepository.GetAllBooksAsync();
            return _mapper.Map<List<BookResponse>>(books);
        }
    }
}