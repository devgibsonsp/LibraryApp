using Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries
{
    public class GetAllBooksQuery : IRequest<List<BookResponse>> { }
}