using Business;
using DataAccess.Repositories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PokeAPI.Filters
{
    public class IsExistOperation<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IRepository<T> repository;

        public IsExistOperation(IRepository<T> repository)
        {
            this.repository = repository;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int Id = Convert.ToInt32(context.RouteData.Values["id"].ToString());

            if (!await repository.Any(x=> x.Id== Id))
            {
                context.Result = new NotFoundObjectResult("Not Found!!");

                return;
            }
            await next();
        }
    }
}