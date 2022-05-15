using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Valorant.API.Filters;
using Valorant.Business;
using Valorant.DTO.Requests;
using Valorant.DTO.Responses;
using Valorant.Entities;

namespace Valorant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService service;

        public AgentController(IAgentService agentService)
        {
            service = agentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAgents()
        {
            var agents = await service.GetAgents();
            return Ok(agents);
        }

        [HttpGet("{id}")]
        [IsExist]
        public async Task<IActionResult> GetAgentById(int id)
        {
            AgentDisplayResponse agent = await service.GetAgent(id);
            return Ok(agent);
        }

        [HttpGet("Search/{key}")]
        public async Task<IActionResult> Search(string key)
        {
            var response = await service.GetAgentByName(key);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAgentRequest request)
        {
            if (ModelState.IsValid)
            {
                int agentId = await service.AddAgent(request);
                return CreatedAtAction(nameof(GetAgentById), routeValues: new { id = agentId }, value: null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [IsExist]
        public async Task<IActionResult> Update(int id, UpdateAgentRequest request)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateAgent(request);
                return Ok();
            }
            return BadRequest(ModelState);

        }

        [HttpDelete("{id}")]
        [IsExist]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAgent(id);
            return Ok();  
        }
    }
}
