using AutoMapper;
using Domain.Entities;
using Application.Responses;

namespace Application.Mappers
{
    public class GetUsersCommandProfile: Profile
    {
        public GetUsersCommandProfile()
        {
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString())); // Convert UserRole enum to string
        }
    }
}
