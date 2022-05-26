using Business;
using DataTransferObject.Requests;
using DataTransferObject.Responses;
using Entities;
using Microsoft.AspNetCore.Mvc;
using PokeAPI.Filters;

namespace PokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService service;

        public PokemonController(IPokemonService pokemonService)
        {
            service = pokemonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPokemonWithClass()
        {
            var pokemons = await service.GetPokemonWithClass();
            return Ok(pokemons);

        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(IsExistOperation<Pokemon>))]
        public async Task<IActionResult> GetPokemonById(int id)
        {
            var pokemon = await service.GetPokemonWithClassById(id);
            return Ok(pokemon);
        }

        [HttpGet("Search/{keywords}")]
        public async Task<IActionResult> Search(string keywords)
        {
            var response = await service.GetPokemonByName(keywords);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPokemonRequest request)
        {
            if (ModelState.IsValid)
            {
                int pokeId = await service.AddPokemon(request);
                return CreatedAtAction(nameof(GetPokemonById), routeValues: new { id = pokeId }, value: null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(IsExistOperation<Pokemon>))]
        public async Task<IActionResult> Update(UpdatePokemonRequest request)
        {
            if(ModelState.IsValid)
            {
                await service.UpdatePokemon(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(IsExistOperation<Pokemon>))]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeletePokemon(id);
            return Ok();
        }


    }
}
