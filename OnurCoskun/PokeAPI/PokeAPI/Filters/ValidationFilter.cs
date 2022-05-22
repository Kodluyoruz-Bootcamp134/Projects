using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PokeAPI.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(i => i.Errors).Select(x => x.ErrorMessage).ToList();
                context.Result= new BadRequestObjectResult(errors);
                return;
            }

            await next();
        }
    }
}
