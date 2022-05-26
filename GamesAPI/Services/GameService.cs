using GamesAPI.Exceptions;
using GamesAPI.Interfaces;
using GamesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Services
{
    public class GameService : IGameService
    {
        readonly IBaseRepository<VideoGame> _gameRepository;
        readonly IBaseRepository<VideoGameGenre> _gameGenreRepository;
        readonly IBaseRepository<Genre> _genreRepository;
        readonly IBaseRepository<DeveloperStudio> _developerStudioRepository;

        public GameService(
            IBaseRepository<VideoGame> gameRepository,
            IBaseRepository<VideoGameGenre> gameGenreRepository,
            IBaseRepository<DeveloperStudio> developerStudioRepository,
            IBaseRepository<Genre> genreRepository)
        {
            _gameRepository = gameRepository;
            _gameGenreRepository = gameGenreRepository;
            _developerStudioRepository = developerStudioRepository;
            _genreRepository = genreRepository;
        }

        public Task<VideoGame> CreateVideoGame(VideoGame game)
        {
            var genres = new List<VideoGameGenre>();
            foreach(var g in game.Genres)
            {
                var genre = _genreRepository.Get().FirstOrDefault(x => x.Id == g.GenreId);

                if (genre == null)
                    throw new NotFoundException("Genre not found!");

                game.Id = Guid.NewGuid();
                var gameGenre = new VideoGameGenre
                {
                    GenreId = genre.Id,
                    GameId = game.Id
                };

                genres.Add(gameGenre);
            };
            var developer = _developerStudioRepository.Get().First(x => x.Id == game.DeveloperStudio.Id);

            game.Genres = genres;
            game.DeveloperStudio = developer;

            var res = _gameRepository.Create(game);
            _gameRepository.Save();
            return Task.FromResult(res);
        }

        public Task<VideoGame> GetVideoGame(Guid id)
        {
            var res = _gameRepository.Get(g => g.Id == id)
                .Include(g => g.DeveloperStudio)
                .Include(g => g.Genres)
                    .ThenInclude(vgg => vgg.Genre)
                .FirstOrDefault();

            if (res == null)
                throw new NotFoundException("Game not found!");

            return Task.FromResult(res);
        }

        public Task<IEnumerable<VideoGame>> GetVideoGames()
        {
            return Task.FromResult(_gameRepository.Get()
                .Include(g => g.DeveloperStudio)
                .Include(g => g.Genres)
                    .ThenInclude(vgg => vgg.Genre)
                .AsEnumerable());
        }

        public Task<VideoGame> UpdateGame(VideoGame game)
        {
            var res = _gameRepository.Get(g => g.Id == game.Id).FirstOrDefault();
            if (res == null)
                throw new NotFoundException("Game for update not found!");

            res.Name = game.Name;

            var developer = _developerStudioRepository.Get()
                .FirstOrDefault(x => x.Id == game.DeveloperStudio.Id || x.Name == game.DeveloperStudio.Name);

            if (developer == null)
                throw new NotFoundException("Developer of the game not found!");

            res.DeveloperStudio = developer;

            var gameGenres = new List<VideoGameGenre>();
            foreach(var g in game.Genres)
            {
                var genre = _genreRepository.Get().FirstOrDefault(x => x.Id == g.GenreId);

                if (genre == null)
                    throw new NotFoundException("Genre of the game not found!");

                var gameGenre = new VideoGameGenre
                {
                    GenreId = genre.Id,
                    GameId = res.Id
                };

                gameGenres.Add(gameGenre);
            }

            res.Genres = gameGenres;

            _gameRepository.Update(res);
            _gameRepository.Save();

            return Task.FromResult(res);
        }

        public async Task<bool> DeleteGame(Guid id)
        {
            var game = await _gameRepository.Get(g => g.Id == id).FirstAsync();
            if (game == null)
                throw new NotFoundException("Game for delete not found!");

            var res = _gameRepository.Delete(game);
            if (res) await _gameRepository.SaveAsync();

            return res;
        }

        public Task<IEnumerable<VideoGame>> GetVideoGamesByGenre(Guid genreId)
        {
            var res = _gameGenreRepository.Get(vgg => vgg.GenreId == genreId)
                .Include(vgg => vgg.Genre)
                .Include(vgg => vgg.Game)
                    .ThenInclude(vg => vg.DeveloperStudio)
                .AsEnumerable()
                .Select(vgg => vgg.Game);

            return Task.FromResult(res);
        }
    }
}
