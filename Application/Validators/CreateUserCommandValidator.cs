using Application.Commands.Users;
using Domain.Contracts;
using FluentValidation;

namespace Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly ILibraryReadRepository _libraryReadRepository;

        public CreateUserCommandValidator(ILibraryReadRepository libraryReadRepository)
        {
            _libraryReadRepository = libraryReadRepository;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(BeUniqueEmail).WithMessage("Email already exists."); 
                // I am aware that it is a security risk to return granular messages on issues with
                // signing up. For simplicity I am keeping it easier to understand on the response
                // given the tight window on this project and likelyhood that I will forget to come
                // back to this
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            var existingUser = await _libraryReadRepository.GetAllUsersAsync();
            return !existingUser.Any(u => u.Email == email);
        }
    }
}