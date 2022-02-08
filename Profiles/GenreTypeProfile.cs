using AutoMapper;
using LibApp.Dtos;
using LibApp.Models;

namespace LibApp.Profiles
{
    public class GenreTypeProfile : Profile
    {
        public GenreTypeProfile()
        {

            CreateMap<Genre, GenreTypeDto>();
            CreateMap<GenreTypeDto, Genre>();

        }
    }
}