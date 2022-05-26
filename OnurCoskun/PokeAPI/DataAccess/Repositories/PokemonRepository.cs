using DataAccess.Data;
using DataTransferObject.Responses;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PokemonRepository : Repository<Pokemon>, IPokemonRepository
    {
        private readonly PokeDbContext context;

        public PokemonRepository(PokeDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonsByName(string name)
        {
            return await context.Pokemon.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<IList<PokemonDisplayResponses>> GetPokemonWithClass()
        {
            var pokemon =  await context.Pokemon.Include(x => x.PokemonClasses).
                ThenInclude(x=> x.Class).Select(x=> new PokemonDisplayResponses
                { 
                Id = x.Id,
                Name = x.Name,
                Birthday = x.Birthday,
                ClassName = x.PokemonClasses.Select(x=> x.Class.Name)
            }) .ToListAsync();

            return pokemon;
        }

        public async Task<PokemonDisplayResponses> GetPokemonWithClassById(int id)
        {
            var pokemon = await context.Pokemon.Where(x=> x.Id==id).Include(x => x.PokemonClasses).
                ThenInclude(x => x.Class).Select(x => new PokemonDisplayResponses
                {
                    Id = x.Id,
                    Name = x.Name,
                    Birthday = x.Birthday,
                    ClassName = x.PokemonClasses.Select(x => x.Class.Name)
                }).FirstOrDefaultAsync();

            return pokemon;
        }
    }
}

