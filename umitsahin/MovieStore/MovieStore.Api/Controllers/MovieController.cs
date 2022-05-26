using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Api.Filters;
using MovieStore.Business.Abstract;
using MovieStore.DTO.Request.Movie;

namespace MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;
        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        [IsExists]
        public async Task<IActionResult> GetMovieDetailById(int id)
        {
            var movie = await _service.GetMovieDetailById(id);
            return Ok(movie);
        }
        [HttpGet("Search/key")]
        public async Task<IActionResult> GetMoviesByName(string key)
        {
            var movie = await _service.GetMoviesByNameAsync(key);
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieDto addMovieDto)
        {
           var movieId= await _service.AddMovie(addMovieDto);
            return Ok();
        }

        [HttpPut("{id}")]
        [IsExists]
        public async Task<IActionResult> UpdateMovie(int id,UpdateMovieDto updateMovieDto)
        {
                if (ModelState.IsValid)
                {
                    await _service.UpdateMovie(updateMovieDto);
                    return Ok();
                }
                return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [IsExists]
        public async  Task<IActionResult> DeleteMovie(int id)
        {
                await _service.DeleteMovie(id);
                return Ok();
        }
    }
}
