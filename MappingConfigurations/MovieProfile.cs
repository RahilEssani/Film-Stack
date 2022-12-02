using AutoMapper;
using FilmStack.Models;

namespace FilmStack.MappingConfigurations
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<TitleData, Movie>();
        }
    }
}
