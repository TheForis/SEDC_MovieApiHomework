using AutoMapper;
using Qinshift.Movies.DomainModels;
using Qinshift.Movies.DTOs;

namespace Qinshift.Movies.Services.Mappers
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ReverseMap();
        }
    }
}
