using MediatR;

namespace Application.Commands
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }
    }
}