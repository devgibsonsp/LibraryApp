using Application.Commands;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly ILibraryWriteRepository _libraryWriteRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(ILibraryWriteRepository libraryWriteRepository, IMapper mapper)
    {
        _libraryWriteRepository = libraryWriteRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Hash the password
        using var sha256 = SHA256.Create();
        var hashedPassword = Convert.ToBase64String(
            sha256.ComputeHash(Encoding.UTF8.GetBytes(request.Password)));

        // Map the command to a domain entity
        var user = _mapper.Map<ApplicationUser>(request);
        user.PasswordHash = hashedPassword;

        try
        {
            // Save the user via the write repository
            return await _libraryWriteRepository.AddUserAsync(user);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("duplicate") ?? false)
        {
            throw new Exception("A user with the same email already exists.");
        }
    }
}