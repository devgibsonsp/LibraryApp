using Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries
{
    public class SearchBooksQuery : IRequest<List<BookResponse>>
    {
        public string Title { get; set; }
    }
}