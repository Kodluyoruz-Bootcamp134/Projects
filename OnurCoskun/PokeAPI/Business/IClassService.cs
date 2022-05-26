using DataTransferObject.Requests;
using DataTransferObject.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IClassService
    {
        Task<IList<ClassDisplayResponses>> GetClasses();
        Task<IList<ClassDisplayResponses>> GetClassesByName(string name);
        Task<IList<ClassDisplayResponses>> GetPokemonThisClass(string name);
        Task DeleteClass(int id);
        Task<int> AddClass(AddClassRequest request);
        Task<ClassDisplayResponses> GetClassById(int id);

    }
}
