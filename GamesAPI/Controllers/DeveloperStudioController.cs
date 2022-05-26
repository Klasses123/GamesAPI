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
    public class DeveloperStudioController
    {
        readonly IDeveloperStudioService _developerStudioService;
        readonly IMapper _mapper;
        public DeveloperStudioController(IDeveloperStudioService developerStudioRepository, IMapper mapper)
        {
            _developerStudioService = developerStudioRepository;
            _mapper = mapper;
        }

        [HttpGet("DeveloperStudio")]
        public async Task<ActionResult<DeveloperStudioViewModel>> Get([FromQuery(Name = "id")] Guid id)
        {
            return new JsonResult(
                _mapper.Map<DeveloperStudioViewModel>(
                    await _developerStudioService.GetById(id)));
        }

        [HttpGet("DeveloperStudios")]
        public async Task<ActionResult<IEnumerable<DeveloperStudioViewModel>>> GetAll()
        {
            return new JsonResult(
                _mapper.Map<List<DeveloperStudioViewModel>>(
                    await _developerStudioService.GetAll()));
        }

        [HttpPost("CreateDeveloperStudio")]
        public async Task<ActionResult<DeveloperStudioViewModel>> CreateDeveloperStudio([FromBody] CreateDeveloperStudioRequest request)
        {
            return new JsonResult(
                _mapper.Map<DeveloperStudioViewModel>(
                    await _developerStudioService.Create(
                        _mapper.Map<DeveloperStudio>(request))));
        }

        [HttpPut("UpdateDeveloperStudio")]
        public async Task<ActionResult<DeveloperStudioViewModel>> UpdateDeveloperStudio([FromBody] UpdateDeveloperStudioRequest request)
        {
            return new JsonResult(
                _mapper.Map<DeveloperStudioViewModel>(
                    await _developerStudioService.Update(
                        _mapper.Map<DeveloperStudio>(request))));
        }

        [HttpDelete("DeleteDeveloperStudio")]
        public async Task<ActionResult<bool>> DeleteDeveloperStudio([FromBody] DeleteDeveloperStudioRequest request)
        {
            return new JsonResult(
                await _developerStudioService.Delete(request.Id));
        }
    }
}
