using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Abstract;

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
        public async Task<IActionResult> GetDirectorById(int id)
        {
            var director = await _service.GetByIdAsync(id);
            return Ok(director);
        }
    }
}
