using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Requests;
using GamesAPI.ViewModels;

namespace GamesAPI.Mapper
{
    public class DeveloperStudioProfile : Profile
    {
        public DeveloperStudioProfile()
        {
            CreateMap<DeveloperStudio, DeveloperStudioViewModel>();
            CreateMap<DeveloperStudioViewModel, DeveloperStudio>();
            CreateMap<CreateDeveloperStudioRequest, DeveloperStudio>();
            CreateMap<UpdateDeveloperStudioRequest, DeveloperStudio>();

        }

        
    }
}
