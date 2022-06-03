using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieStore.DataAccess.Repositories.Abstract;
using MovieStore.Entities.Common;

namespace MovieStore.Api.Filters;

public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
{
    private readonly IRepository<T> _repository;

    public NotFoundFilter(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task  OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ActionArguments.ContainsKey("id"))
        {
            context.Result = new BadRequestObjectResult("id değeri zorunludur....");
        }
        else
        {
            var id = (int)context.ActionArguments["id"];

            if (!await _repository.AnyAsync(id))
            {
                context.Result = new NotFoundObjectResult(new { message = $"{id} id'li film bulunamadı.." });
            }

            else
            {
                await next.Invoke();
            }
        }
    }
}
