using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valorant.DTO.Requests;
using Valorant.DTO.Responses;
using Valorant.Entities;

namespace Valorant.Business
{
    public interface IAgentService
    {
        Task<IList<AgentDisplayResponse>> GetAgents();
        Task<AgentDisplayResponse> GetAgent(int id);
        Task<IList<AgentDisplayResponse>> GetAgentByName(string key);
        Task<int> AddAgent(AddAgentRequest request);
    }
}
