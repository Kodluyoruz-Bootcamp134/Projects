using DataTransferObject.Responses;
using Entities;

namespace DataAccess.Repositories
{
    public interface IPokemonRepository : IRepository<Pokemon>
    {
        Task<IEnumerable<Pokemon>> GetPokemonsByName(string name);
        Task<IList<PokemonDisplayResponses>> GetPokemonWithClass();
        Task<PokemonDisplayResponses> GetPokemonWithClassById(int id);
    }
}