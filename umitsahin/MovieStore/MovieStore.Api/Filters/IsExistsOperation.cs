using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieStore.Business.Abstract;

namespace MovieStore.Api.Filters
{
    public class IsExistsOperation : IAsyncActionFilter
    {
        private readonly IMovieService _service;
        public IsExistsOperation(IMovieService service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult("id değeri zorunludur....");
            }
            else
            {
                var id = (int)context.ActionArguments["id"];

                if (!await _service.IsMovieExists(id))
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
}
