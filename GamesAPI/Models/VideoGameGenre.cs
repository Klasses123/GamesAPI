using GamesAPI.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Models
{
    public class VideoGameGenre : IDataModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid GameId { get; set; }
        public virtual VideoGame Game { get; set; }
        public Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
