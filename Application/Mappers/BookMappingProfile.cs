using AutoMapper;
using Application.Responses;
using Domain.Entities;

namespace Application.Mappers
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            // Map from Book to BookResponse
            CreateMap<Book, BookResponse>()
                .ForMember(dest => dest.CustomerReviews, opt => opt.MapFrom(src => src.Reviews));

            // Map from Review to ReviewResponse
            CreateMap<Review, ReviewResponse>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.UserName));
        }
    }
}