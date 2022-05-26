using Characters.DTO.Requests;
using Characters.DTO.Responses;
using Characters.Entities;
using Characters.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddleEarthApi.Filters;

namespace MiddleEarthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly IService _characterService;

        public CharactersController(IService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _characterService.GetAll());
        }
        
        [HttpGet("{id}")]
        [IsExist]
        public async Task<IActionResult> GetById(int id)
        {
            CharactersRespons character = await _characterService.GetById(id);
            return Ok(character);
        }

        [HttpGet("Find/{name}")]
        public async Task<IActionResult> Find(string name)
        {
            var characters = await _characterService.GetByName(name);
            return Ok(characters);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Add(AddCharacterRequest request)
        {
            if (ModelState.IsValid)
            {
                int characterId = await _characterService.AddCharacter(request);
                return CreatedAtAction(nameof(GetById), routeValues: new { id = characterId }, value: null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [IsExist]
        public async Task<IActionResult> Update(int id, UpdateCharacterRequest request)
        {
            if (ModelState.IsValid)
            {
                await _characterService.UpdateCharacter(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [IsExist]
        public async Task<IActionResult> Delete(int id)
        {
             await _characterService.DeleteCharacter(id);
             return Ok();
        }
    }
}
