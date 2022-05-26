using GamesAPI.Models;
using GamesAPI.ViewModels;

namespace GamesAPI.Requests
{
    public class UpdateGameRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual DeveloperStudioViewModel DeveloperStudio { get; set; }
        public virtual List<GenreViewModel> Genres { get; set; }
    }
}
