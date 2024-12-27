using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class EditBookCommandValidator : AbstractValidator<EditBookCommand>
    {
        public EditBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.CoverImageUrl).NotEmpty().WithMessage("Cover image URL is required.");
            RuleFor(x => x.Publisher).NotEmpty().WithMessage("Publisher is required.");
            RuleFor(x => x.PublicationDate).LessThanOrEqualTo(DateTime.Now).WithMessage("Publication date cannot be in the future.");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.");
            RuleFor(x => x.ISBN).NotEmpty().WithMessage("ISBN is required.");
            RuleFor(x => x.PageCount).GreaterThan(0).WithMessage("Page count must be greater than 0.");
        }
    }
}