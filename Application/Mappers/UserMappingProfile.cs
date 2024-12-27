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
            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Hashing happens in the handler
                .ForMember(dest => dest.Reviews, opt => opt.Ignore())      // Set defaults
                .ForMember(dest => dest.Checkouts, opt => opt.Ignore());

            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

            CreateMap<User, UserLoginResponse>();
        }
    }
}