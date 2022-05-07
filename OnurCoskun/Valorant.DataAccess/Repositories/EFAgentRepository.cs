using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valorant.DataAccess.Data;
using Valorant.Entities;

namespace Valorant.DataAccess.Repositories
{
    public class EFAgentRepository : IAgentRepository
    {
        private ValorantDbContext context;
        public EFAgentRepository(ValorantDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Agent entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Agent>> GetAgentsByName(string name)
        {
            return await context.Agents.Where(a=> a.CodeName.Contains(name)).ToListAsync();
        }

        public async Task<IList<Agent>> GetAll()
        {
            var agents = await context.Agents.ToListAsync();
            return agents;
        }

        public async Task<Agent> GetById(int Id)
        {
           return await context.Agents.FindAsync(Id);
        }
    }
}
