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
    public class GenreController
    {
        readonly IGenreService _genreService;
        readonly IMapper _mapper;
        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet("Genre")]
        public async Task<ActionResult<GenreViewModel>> Get([FromQuery(Name = "id")] Guid id)
        {
            return new JsonResult(
                _mapper.Map<GenreViewModel>(
                    await _genreService.GetById(id)));
        }

        [HttpGet("Genres")]
        public async Task<ActionResult<IEnumerable<GenreViewModel>>> GetAll()
        {
            return new JsonResult(
                _mapper.Map<List<GenreViewModel>>(
                    await _genreService.GetAll()));
        }

        [HttpPost("CreateGenre")]
        public async Task<ActionResult<GenreViewModel>> CreateGenre([FromBody] CreateGenreRequest request)
        {
            return new JsonResult(
                _mapper.Map<GenreViewModel>(
                    await _genreService.Create(
                        _mapper.Map<Genre>(request))));
        }

        [HttpPut("UpdateGenre")]
        public async Task<ActionResult<GenreViewModel>> UpdateGenre([FromBody] UpdateGenreRequest request)
        {
            return new JsonResult(
                _mapper.Map<GenreViewModel>(
                    await _genreService.Update(
                        _mapper.Map<Genre>(request))));
        }

        [HttpDelete("DeleteGenre")]
        public async Task<ActionResult<bool>> DeleteGenre([FromBody] DeleteGenreRequest request)
        {
            return new JsonResult(
                await _genreService.Delete(request.Id));
        }
    }
}
