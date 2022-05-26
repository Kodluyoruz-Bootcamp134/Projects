using Base.Api.Application.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Api.Infrastructure.Attributes;

public class ValidationFilterAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var error = context.ModelState.Values.SelectMany(i => i.Errors).Select(x => x.ErrorMessage).First();

            context.Result = new ObjectResult(Response<NoContent>.Fail(message: error)) { StatusCode = 500 };

            return;
        }
        await next();
    }
}