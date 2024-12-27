using Application.Responses;
using MediatR;

namespace Application.Queries.Books
{
    public class GetBookByIdQuery : IRequest<BookResponse>
    {
        public int Id { get; set; }
    }
}