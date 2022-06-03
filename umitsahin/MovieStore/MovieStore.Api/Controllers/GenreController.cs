using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Api.Filters;
using MovieStore.Business.Abstract;
using MovieStore.DTO.Request.Genre;
using MovieStore.Entities;

namespace MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _service;

        public GenreController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genre = await _service.GetByIdAsync(id);
            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre(AddGenreDto addGenreDto)
        {
            var genreId = await _service.AddGenre(addGenreDto);
            return Ok(genreId);
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Genre>))]
        public async Task<IActionResult> UpdateMovie(int id, UpdateGenreDto updateGenreDto)
        {
            await _service.UpdateGenre(updateGenreDto);
            return Ok();

        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Movie>))]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _service.DeleteGenre(id);
            return Ok();
        }
    }
}
