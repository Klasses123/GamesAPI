using AutoMapper;
using GamesAPI.Interfaces;
using GamesAPI.Models;
using GamesAPI.Requests;
using GamesAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GamesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoGameController
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        public VideoGameController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpGet("Games")]
        public async Task<ActionResult<IEnumerable<VideoGame>>> GetGames()
        {
            return new JsonResult(
                _mapper.Map<List<VideoGameViewModel>>(await _gameService.GetVideoGames()));
        }

        [HttpGet("Game")]
        public async Task<ActionResult<VideoGameViewModel>> GetGame([FromQuery(Name = "id")] Guid id)
        {
            return new JsonResult(
                _mapper.Map<VideoGameViewModel>(await _gameService.GetVideoGame(id)));
        }

        [HttpGet("Genre")]
        public async Task<ActionResult<VideoGameViewModel>> GetGamesByGenre([FromQuery(Name = "genreId")] Guid id)
        {
            return new JsonResult(
                _mapper.Map<List<VideoGameViewModel>>(await _gameService.GetVideoGamesByGenre(id)));
        }

        [HttpPut("UpdateGame")]
        public async Task<ActionResult<VideoGameViewModel>> UpdateGame([FromBody] UpdateGameRequest request)
        {
            return new JsonResult(
                _mapper.Map<VideoGameViewModel>(
                    await _gameService.UpdateGame(
                        _mapper.Map<VideoGame>(request))));
        }

        [HttpPost("CreateGame")]
        public async Task<ActionResult<VideoGameViewModel>> CreateGame([FromBody] CreateGameRequest request)
        {
            return new JsonResult(
                _mapper.Map<VideoGameViewModel>(
                    await _gameService.CreateVideoGame(
                        _mapper.Map<VideoGame>(request))));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> DeleteGame([FromBody] DeleteGameRequest request)
        {
            return new JsonResult(await _gameService.DeleteGame(request.GameId));
        }
    }
}
