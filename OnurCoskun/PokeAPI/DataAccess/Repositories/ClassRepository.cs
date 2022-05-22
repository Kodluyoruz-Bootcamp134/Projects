using DataAccess.Data;
using DataTransferObject.Responses;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DataAccess.Repositories
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public readonly PokeDbContext context;
        public ClassRepository(PokeDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Class>> GetClassesByName(string name)
        {
            return await context.Classes.Where(x=> x.Name.Contains(name)).ToListAsync();
        }

        public async Task<IList<ClassDisplayResponses>> GetPokemonThisClass(string name)
        {
            return await context.Classes.Include(x => x.PokemonClasses)
                                        .ThenInclude(x => x.Pokemon)
                                        .Where(x=> x.Name == name).Select(p => new ClassDisplayResponses
                                        {
                                            Id = p.Id,
                                            Name = p.Name,
                                            PokemonName = p.PokemonClasses.Select(p=> p.Pokemon.Name)
                                        }).ToListAsync();
        }
    }
}
