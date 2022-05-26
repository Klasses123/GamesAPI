using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Requests;
using GamesAPI.ViewModels;

namespace GamesAPI.Mapper
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreViewModel>();
            CreateMap<GenreViewModel, Genre>();
            CreateMap<CreateGenreRequest, Genre>();
            CreateMap<UpdateGenreRequest, Genre>();
            CreateMap<GenreViewModel, VideoGameGenre>()
                .ForMember(set => set.GenreId, opt => opt.MapFrom(src => src.Id))
                .ForMember(set => set.Genre, opt => opt.MapFrom(src => src.ToGenre()));
        }
    }
}
