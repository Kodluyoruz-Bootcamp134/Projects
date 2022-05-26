using Characters.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MiddleEarthApi.Filters
{
    public class IsExistOperation:IAsyncActionFilter
    {
        private readonly IService _service;

        public IsExistOperation(IService service)
        {
            this._service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult("Id is required!");
            }
            else
            {
                var id=(int)context.ActionArguments["id"];
                if (!await _service.IsCharacterExist(id))
                {
                    context.Result = new NotFoundObjectResult(new { message = $"Charcter with id:{id} not found" });
                }
                else
                {
                    await next.Invoke();
                }
            }
        }
    }
}
