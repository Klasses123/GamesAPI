using GamesAPI.Models;

namespace GamesAPI.Interfaces
{
    public interface IDeveloperStudioService
    {
        Task<DeveloperStudio> GetById(Guid id);
        Task<IEnumerable<DeveloperStudio>> GetAll();
        Task<bool> Delete(Guid id);
        Task<DeveloperStudio> Update(DeveloperStudio genre);
        Task<DeveloperStudio> Create(DeveloperStudio genre);
    }
}
