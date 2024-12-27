using Application.Queries;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<List<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = _userManager.Users.ToList(); // Retrieve users
        var userResponses = new List<UserResponse>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user); // Fetch roles for each user
            var userResponse = _mapper.Map<UserResponse>(user);
            userResponse.Role = roles.FirstOrDefault(); // Assuming one role per user
            userResponses.Add(userResponse);
        }

        return userResponses;
    }
}