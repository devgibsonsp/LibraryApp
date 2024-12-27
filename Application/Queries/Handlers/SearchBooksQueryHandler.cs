using Application.Queries;
using Application.Responses;
using AutoMapper;
using Domain.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Books
{
    public class SearchBooksQueryHandler : IRequestHandler<SearchBooksQuery, List<BookResponse>>
    {
        private readonly ILibraryReadRepository _libraryReadRepository;
        private readonly IMapper _mapper;

        public SearchBooksQueryHandler(ILibraryReadRepository libraryReadRepository, IMapper mapper)
        {
            _libraryReadRepository = libraryReadRepository;
            _mapper = mapper;
        }

        public async Task<List<BookResponse>> Handle(SearchBooksQuery request, CancellationToken cancellationToken)
        {
            // Fetch books matching the partial title (case-insensitive)
            var books = await _libraryReadRepository.SearchBooksByTitleAsync(request.Title);

            // Map to response objects
            return _mapper.Map<List<BookResponse>>(books);
        }
    }
}