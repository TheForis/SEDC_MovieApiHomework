using AutoMapper;
using Qinshift.Movies.DomainModels;
using Qinshift.Movies.DTOs;
using Qinshift.Movies.Services.Helper;

namespace Qinshift.Movies.Services.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => $"{z.FirstName} {z.LastName}"))
                .ForMember(x=> x.Token, y=>  y.MapFrom(z=> TokenHelper.GenerateToken(z)))
                .ForMember(x => x.UserName, y => y.Ignore())
                .ReverseMap();
        }
        
    }
}
