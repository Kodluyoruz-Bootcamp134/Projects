using Characters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.Dal.Repository
{
    public interface ICharacterRepository:IRepository<Character>
    {
        Task<IEnumerable<Character>> GetByName(string name);
    }
}
