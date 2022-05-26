using GamesAPI.ViewModels;

namespace GamesAPI.Requests
{
    public class CreateGameRequest
    {
        public string Name { get; set; }
        public DeveloperStudioViewModel DeveloperStudio { get; set; }
        public virtual List<GenreViewModel> Genres { get; set; }
    }
}
