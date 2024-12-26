using AutoMapper;
using Application.Commands.Users;
using Domain.Entities;

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
        }
    }
}