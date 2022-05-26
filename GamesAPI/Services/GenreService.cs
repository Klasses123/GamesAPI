using GamesAPI.Exceptions;
using GamesAPI.Interfaces;
using GamesAPI.Models;

namespace GamesAPI.Services
{
    public class GenreService : IGenreService
    {
        readonly IBaseRepository<Genre> _genreRepository;
        public GenreService(IBaseRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Genre> Create(Genre genre)
        {
            var res = _genreRepository.Create(genre);
            await _genreRepository.SaveAsync();
            return res;
        }

        public async Task<bool> Delete(Guid id)
        {
            var genre = _genreRepository.GetById(id);
            if (genre == null)
                throw new NotFoundException("Genre for delete not found!");

            var res = _genreRepository.Delete(genre);
            if (res) await _genreRepository.SaveAsync();

            return res;
        }

        public Task<IEnumerable<Genre>> GetAll()
        {
            return Task.FromResult(_genreRepository.Get().AsEnumerable());
        }

        public Task<Genre> GetById(Guid id)
        {
            var res = _genreRepository.GetById(id);
            if (res == null)
                throw new NotFoundException("Genre not found!");
            return Task.FromResult(res);
        }

        public Task<Genre> Update(Genre genre)
        {
            var res = _genreRepository.Get(x => x.Id == genre.Id).FirstOrDefault();
            if (res == null)
                throw new NotFoundException("Genre for update not found!");

            res.Name = genre.Name;
            _genreRepository.Update(res);
            _genreRepository.Save();

            return Task.FromResult(res);
        }

    }
}
