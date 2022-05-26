using GamesAPI.Models;

namespace GamesAPI.Interfaces
{
    public interface IGameService
    {
        Task<VideoGame> CreateVideoGame(VideoGame game);
        Task<VideoGame> GetVideoGame(Guid id);
        Task<IEnumerable<VideoGame>> GetVideoGames();
        Task<VideoGame> UpdateGame(VideoGame game);
        Task<bool> DeleteGame(Guid id);
        Task<IEnumerable<VideoGame>> GetVideoGamesByGenre(Guid genreId);
    }
}
