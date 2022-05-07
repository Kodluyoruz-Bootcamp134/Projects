using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valorant.Entities;

namespace Valorant.DataAccess.Repositories
{
    public interface IAgentRepository : IRepository<Agent>
    {
        Task<IEnumerable<Agent>> GetAgentsByName(string name);
    }
}
