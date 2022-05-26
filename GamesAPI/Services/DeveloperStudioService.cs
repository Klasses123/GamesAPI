using GamesAPI.Exceptions;
using GamesAPI.Interfaces;
using GamesAPI.Models;

namespace GamesAPI.Services
{
    public class DeveloperStudioService : IDeveloperStudioService
    {
        readonly IBaseRepository<DeveloperStudio> _developerStudioRepository;
        public DeveloperStudioService(IBaseRepository<DeveloperStudio> developerStudioRepository)
        {
            _developerStudioRepository = developerStudioRepository;
        }

        public async Task<DeveloperStudio> Create(DeveloperStudio dev)
        {
            var res = _developerStudioRepository.Create(dev);
            await _developerStudioRepository.SaveAsync();
            return res;
        }

        public async Task<bool> Delete(Guid id)
        {
            var dev = _developerStudioRepository.GetById(id);
            if (dev == null)
                throw new NotFoundException("Developer studio for delete not found!");

            var res = _developerStudioRepository.Delete(dev);
            if (res) await _developerStudioRepository.SaveAsync();
            return res;
        }

        public Task<IEnumerable<DeveloperStudio>> GetAll()
        {
            return Task.FromResult(_developerStudioRepository.Get().AsEnumerable());
        }

        public Task<DeveloperStudio> GetById(Guid id)
        {
            var dev = _developerStudioRepository.GetById(id);
            if (dev == null)
                throw new NotFoundException("Developer studio not found!");

            return Task.FromResult(dev);
        }

        public Task<DeveloperStudio> Update(DeveloperStudio dev)
        {
            var res = _developerStudioRepository.Get(x => x.Id == dev.Id).FirstOrDefault();
            if (res == null)
                throw new NotFoundException("Developer studion for update not found");

            res.Name = dev.Name;
            _developerStudioRepository.Update(res);
            _developerStudioRepository.Save();

            return Task.FromResult(res);
        }
    }
}
