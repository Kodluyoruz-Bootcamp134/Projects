using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valorant.Entities;

namespace Valorant.DataAccess.Repositories
{
    public class FakeAgentRepository : IAgentRepository
    {
        private List<Agent> agents;

        public FakeAgentRepository()
        {
            agents = new List<Agent>
            {
                new Agent { Id = 1, CodeName = "Jett", Gender ="Female", Origin = "South Korea", Race = "Radiant", RealName ="Sunwoo Han", Role= "Duelist", ImageUrl="http://placehold.it/300x300"},
                new Agent { Id = 2, CodeName = "Phoenix", Gender ="Male", Origin = "United Kingdom", Race = "Radiant", RealName ="Jamie Adeyemi", Role= "Duelist", ImageUrl="http://placehold.it/300x300"},
                new Agent { Id = 3, CodeName = "Fade", Gender ="Female", Origin = "Turkey", Race = "Radiant", Role= "İnitiator", ImageUrl= "http://placehold.it/300x300"}
            };
        }

        public Task Add(Agent entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Agent>> GetAgentsByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Agent>> GetAll()
        {
            return agents;
        }

        public Task<Agent> GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
