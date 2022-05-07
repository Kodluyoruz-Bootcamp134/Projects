using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valorant.DataAccess.Repositories;
using Valorant.DTO.Requests;
using Valorant.DTO.Responses;
using Valorant.Entities;

namespace Valorant.Business
{
    public class AgentService : IAgentService
    {
        private readonly IMapper mapper;
        private readonly IAgentRepository agentRepository;
        private List<Agent> agents;

        public AgentService(IAgentRepository agentRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.agentRepository = agentRepository;
        }

        public async Task<int> AddAgent(AddAgentRequest request)
        {
            var agent = mapper.Map<Agent>(request);
            await agentRepository.Add(agent);
            return agent.Id;
        }

        public async Task<AgentDisplayResponse> GetAgent(int id)
        {
            var agent = await agentRepository.GetById(id);
            var result = mapper.Map<AgentDisplayResponse>(agent);
            return result;
        }

        public async Task<IList<AgentDisplayResponse>> GetAgentByName(string key)
        {
            var agents = await agentRepository.GetAgentsByName(key);
            var result = mapper.Map<IList<AgentDisplayResponse>>(agents);
            return result;
        }

        public async Task<IList<AgentDisplayResponse>> GetAgents()
        {
            var agents = await agentRepository.GetAll();
            var result = mapper.Map<IList<AgentDisplayResponse>>(agents);
            return result;
        }

    }
}
