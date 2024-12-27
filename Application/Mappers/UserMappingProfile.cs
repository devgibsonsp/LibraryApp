using AutoMapper;
using Application.Commands;
using Domain.Entities;
using Application.Responses;

namespace Application.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserCommand, ApplicationUser>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Hashing happens in the handler
                .ForMember(dest => dest.Reviews, opt => opt.Ignore())      // Set defaults
                .ForMember(dest => dest.Checkouts, opt => opt.Ignore());

            CreateMap<ApplicationUser, UserResponse>()
                .ForMember(dest => dest.Role, opt => opt.Ignore()); // Role must be set dynamically

            CreateMap<ApplicationUser, UserLoginResponse>();
        }
    }
}