using Base.Api.Application.Interfaces.Services;
using Base.Api.Application.Interfaces.UnitOfWork;
using Base.Api.Application.Models.Dtos;
using Base.Api.Application.Services;
using Base.Api.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Api.Infrastructure.Attributes
{
    public class NotFoundFilterAttribute<TEntity> : IAsyncActionFilter where TEntity : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly HashService _hashService;
        private readonly IIdentityService _identityService;

        public NotFoundFilterAttribute(IUnitOfWork unitOfWork, HashService hashService, IIdentityService identityService)
        {
            _unitOfWork = unitOfWork;
            _hashService = hashService;
            _identityService = identityService;
        }

        public bool GetData(string id)
        {
            int decodeId = _hashService.Decode(id);

            if (decodeId == 0) return false;

            if (typeof(TEntity) is IAuthRequired entity)
            {
                return _unitOfWork.ReadRepository<TEntity>()
                    .Any(x => x.Id == decodeId && entity.ApplicationUserId == _identityService.GetUserDecodeId);
            }

            return _unitOfWork.ReadRepository<TEntity>().Any(x => x.Id == decodeId);
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string GetId()
            {
                string routeId = (string)context.RouteData.Values["id"];

                if (!string.IsNullOrEmpty(routeId))
                {
                    return routeId;
                }

                var obj = context.ActionArguments.First().Value;

                string modelId = obj.GetType().GetProperties().First(o => o.Name == "Id").GetValue(obj, null).ToString();

                if (!string.IsNullOrEmpty(modelId))
                {
                    return modelId;
                }

                return null;
            }

            var id = GetId();

            if (string.IsNullOrEmpty(id))
            {
                context.Result = new NotFoundObjectResult(Response<NoContent>.Fail("Id değeri boş olamaz", 404));
                return;
            }

            if (!GetData(id))
            {
                context.Result = new NotFoundObjectResult(Response<NoContent>.Fail("Böyle bir veri bulunamadı.", 404));
                return;
            }
            await next();
        }
    }
}