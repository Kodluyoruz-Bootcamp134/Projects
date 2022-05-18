using DataTransferObject.Requests;
using DataTransferObject.Responses;
using Entities;

namespace Business
{
    public interface IPokemonService
    {
        Task<IList<PokemonDisplayResponses>> GetPokemons();
        Task<PokemonDisplayResponses> GetPokemon(int id);
        Task<IList<PokemonDisplayResponses>> GetPokemonByName(string key);
        Task<int> AddPokemon(AddPokemonRequest request);
        Task UpdatePokemon(UpdatePokemonRequest request);
        Task DeletePokemon(int id);
        Task<IList<PokemonDisplayResponses>> GetPokemonWithClass();
        Task<PokemonDisplayResponses> GetPokemonWithClassById(int id);
    }
}
