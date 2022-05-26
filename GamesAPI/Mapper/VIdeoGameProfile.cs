using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Requests;
using GamesAPI.ViewModels;

namespace GamesAPI.Mapper
{
    public class VIdeoGameProfile : Profile
    {
        public VIdeoGameProfile()
        {
            CreateMap<UpdateGameRequest, VideoGame>()
                .ForMember(set => set.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(set => set.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(set => set.DeveloperStudio, opt => opt.MapFrom(src => src.DeveloperStudio))
                .ForMember(set => set.Genres, opt => opt.MapFrom(src => src.Genres))
                .MaxDepth(2);

            CreateMap<VideoGame, VideoGameViewModel>()
                .ForMember(set => set.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(set => set.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(set => set.DeveloperStudio, opt => opt.MapFrom(src => src.DeveloperStudio))
                .ForMember(set => set.Genres, opt => opt.MapFrom(src => src.Genres.Select(x => x.Genre).ToList()))
                .MaxDepth(2);

            CreateMap<CreateGameRequest, VideoGame>().ForMember(set => set.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(set => set.DeveloperStudio, opt => opt.MapFrom(src => src.DeveloperStudio))
                .ForMember(set => set.Genres, opt => opt.MapFrom(src => src.Genres));


        }
    }
}
