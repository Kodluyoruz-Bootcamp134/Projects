using DataTransferObject.Responses;
using Entities;

namespace DataAccess.Repositories
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<IEnumerable<Class>> GetClassesByName(string name);
        Task<IList<ClassDisplayResponses>> GetPokemonThisClass(string name);

    }
}
