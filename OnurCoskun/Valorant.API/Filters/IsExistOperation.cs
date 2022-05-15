using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Valorant.Business;

namespace Valorant.API.Filters
{
    public class IsExistOperation : IAsyncActionFilter
    {
        private readonly IAgentService agentService;

        public IsExistOperation(IAgentService agentService)
        {
            this.agentService = agentService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult("Id is required");
            }
            else
            {
                var id = (int)context.ActionArguments["id"];
                if (!await agentService.IsAgentExist(id))
                {
                    context.Result = new NotFoundObjectResult(new { message = $"Agent is not found with {id} ID" });
                }
                else
                {
                    await next.Invoke();
                }
                
            }
        }
    }
}
