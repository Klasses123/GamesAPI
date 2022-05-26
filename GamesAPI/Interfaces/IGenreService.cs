using GamesAPI.Models;

namespace GamesAPI.Interfaces
{
    public interface IGenreService
    {
        Task<Genre> GetById(Guid id);
        Task<IEnumerable<Genre>> GetAll();
        Task<bool> Delete(Guid id);
        Task<Genre> Update(Genre genre);
        Task<Genre> Create(Genre genre);
    }
}
