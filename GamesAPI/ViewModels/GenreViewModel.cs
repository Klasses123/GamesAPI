using GamesAPI.Models;

namespace GamesAPI.ViewModels
{
    public class GenreViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Genre ToGenre()
        {
            return new Genre
            {
                Id = this.Id,
                Name = this.Name,
            };
        }
    }
}
