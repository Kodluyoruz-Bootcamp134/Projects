using Business;
using DataTransferObject.Requests;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeAPI.Filters;

namespace PokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService service;

        public ClassController(IClassService classService)
        {
            service = classService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClasses()
        {
            var classes = await service.GetClasses();
            return Ok(classes);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetPokemonThisClass(string name)
        {
            var pokemon = await service.GetPokemonThisClass(name);
            return Ok(pokemon);
        }

        [HttpGet("Search/{key}")]
        public async Task<IActionResult> GetClassesByName(string key)
        {
            var classes = await service.GetClassesByName(key);
            return Ok(classes);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(IsExistOperation<Class>))]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteClass(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddClass(AddClassRequest request)
        {
            if (ModelState.IsValid)
            {
                int classId = await service.AddClass(request);
                if (classId != 0)
                {
                    return CreatedAtAction(nameof(Delete), routeValues: new { Id = classId }, value: null);
                } 
            }
            return BadRequest(ModelState);
        }

    }
}
