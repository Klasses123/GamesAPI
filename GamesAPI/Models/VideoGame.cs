using GamesAPI.Interfaces;

namespace GamesAPI.Models
{
    public class VideoGame : IDataModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual DeveloperStudio DeveloperStudio { get; set; }
        public virtual List<VideoGameGenre> Genres { get; set; }
    }
}
