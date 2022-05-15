using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Valorant.API.Filters
{
    public class IsExistAttribute : TypeFilterAttribute
    {
        public IsExistAttribute() : base(typeof(IsExistOperation))
        {

        }
    }
}
