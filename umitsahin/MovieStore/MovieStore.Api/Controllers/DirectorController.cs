using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Api.Filters;
using MovieStore.Business.Abstract;
using MovieStore.DTO.Request.Director;
using MovieStore.Entities;

namespace MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _service;

        public DirectorController(IDirectorService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetDirectors()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Director>))]
        public async Task<IActionResult> GetDirectorById(int id)
        {
            var director = await _service.GetByIdAsync(id);
            return Ok(director);
        }
        [HttpPost]
        public async Task<IActionResult> AddGenre(AddDirectorDto addDirectorDto)
        {
            var genreId = await _service.AddDirector(addDirectorDto);
            return Ok(genreId);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Director>))]
        public async Task<IActionResult> UpdateMovie(int id, UpdateDirectorDto updateDirectorDto)
        {
            await _service.UpdateDirector(updateDirectorDto);
            return Ok();

        }
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Director>))]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            await _service.DeleteDirector(id);
            return Ok();
        }
    }
}
