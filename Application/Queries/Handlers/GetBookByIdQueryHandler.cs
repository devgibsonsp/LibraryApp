using Application.Queries.Books;
using Application.Responses;
using AutoMapper;
using Domain.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Books
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookResponse>
    {
        private readonly ILibraryReadRepository _libraryReadRepository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(ILibraryReadRepository libraryReadRepository, IMapper mapper)
        {
            _libraryReadRepository = libraryReadRepository;
            _mapper = mapper;
        }

        public async Task<BookResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            // Fetch the book with related data
            var book = await _libraryReadRepository.GetBookByIdAsync(request.Id);

            // Handle not found
            if (book == null)
                throw new KeyNotFoundException($"Book with ID {request.Id} not found.");

            // Map to BookResponse
            return _mapper.Map<BookResponse>(book);
        }
    }
}