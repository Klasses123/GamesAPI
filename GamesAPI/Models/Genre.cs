using GamesAPI.Interfaces;

namespace GamesAPI.Models
{
    public class Genre : IDataModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<VideoGameGenre> Genres { get; set; }
    }
}
