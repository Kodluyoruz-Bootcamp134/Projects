using Base.Api.Application.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Base.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    [NonAction]
    public IActionResult Result<T>(Response<T> response)
    {
        if (response.StatusCode == 204)
        {
            return NoContent();
        }

        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }
}