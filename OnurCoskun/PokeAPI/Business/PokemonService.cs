using AutoMapper;
using DataAccess.Repositories;
using DataTransferObject.Requests;
using DataTransferObject.Responses;
using Entities;

namespace Business
{
    public class PokemonService : IPokemonService
    {
        private readonly IMapper mapper;
        private readonly IPokemonRepository pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.pokemonRepository = pokemonRepository;
        }

        public async Task<int> AddPokemon(AddPokemonRequest request)
        {
            var pokemon = mapper.Map<Pokemon>(request);
            await pokemonRepository.Add(pokemon);
            return pokemon.Id;
        }

        public async Task DeletePokemon(int id)
        {
            await pokemonRepository.Delete(id);
        }

        public async Task<PokemonDisplayResponses> GetPokemon(int id)
        {
            var pokemon = await pokemonRepository.GetById(id);
            var result = mapper.Map<PokemonDisplayResponses>(pokemon);
            return result;

        }

        public async Task<IList<PokemonDisplayResponses>> GetPokemonByName(string key)
        {
            var pokemons = await pokemonRepository.GetPokemonsByName(key);
            var result = mapper.Map<IList<PokemonDisplayResponses>>(pokemons);
            return result;
        }

        public async Task<IList<PokemonDisplayResponses>> GetPokemons()
        {
            var pokemons = await pokemonRepository.GetAll();
            var result = mapper.Map<IList<PokemonDisplayResponses>>(pokemons);
            return result;
        }

        public async Task UpdatePokemon(UpdatePokemonRequest request)
        {
            var pokemon = mapper.Map<Pokemon>(request);
            await pokemonRepository.Update(pokemon);
        }

        public async Task<IList<PokemonDisplayResponses>> GetPokemonWithClass()
        {
            return await pokemonRepository.GetPokemonWithClass();
        }

        public async Task<PokemonDisplayResponses> GetPokemonWithClassById(int id)
        {
            return await pokemonRepository.GetPokemonWithClassById(id);
        }
    }
}
