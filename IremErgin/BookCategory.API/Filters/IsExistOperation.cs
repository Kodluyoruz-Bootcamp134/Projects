using BookCategory.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookCategory.API.Filters
{
    public class IsExistOperation : IAsyncActionFilter
    {
        private readonly IBookService bookService;

        public IsExistOperation(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult("Id gereklidir!");
            }
            else
            {
                var id = (int)context.ActionArguments["id"];

                if (!await bookService.IsBookExists(id))
                {
                    context.Result = new NotFoundObjectResult(new { message = $"{id} id'li kitap bulunamadı!" });

                }
                else 
                {
                    await next.Invoke();
                }
                
            }

            

        }
    }
}
