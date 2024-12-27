using Application.Commands;
using Domain.Contracts;
using MediatR;

public class EditBookCommandHandler : IRequestHandler<EditBookCommand, Unit>
{
    private readonly ILibraryReadRepository _libraryReadRepository;
    private readonly ILibraryWriteRepository _libraryWriteRepository;

    public EditBookCommandHandler(
        ILibraryReadRepository libraryReadRepository,
        ILibraryWriteRepository libraryWriteRepository)
    {
        _libraryReadRepository = libraryReadRepository;
        _libraryWriteRepository = libraryWriteRepository;
    }

    public async Task<Unit> Handle(EditBookCommand request, CancellationToken cancellationToken)
    {
        // Fetch the book from the read repository
        var book = await _libraryReadRepository.GetBookByIdAsync(request.Id);
        if (book == null)
        {
            throw new KeyNotFoundException($"Book with ID {request.Id} not found.");
        }

        // Update the book's details
        book.Title = request.Title;
        book.Author = request.Author;
        book.Description = request.Description;
        book.CoverImageUrl = request.CoverImageUrl;
        book.Publisher = request.Publisher;
        book.PublicationDate = request.PublicationDate;
        book.Category = request.Category;
        book.ISBN = request.ISBN;
        book.PageCount = request.PageCount;

        // Save changes using the write repository
        await _libraryWriteRepository.UpdateBookAsync(book);

        return Unit.Value;
    }
}