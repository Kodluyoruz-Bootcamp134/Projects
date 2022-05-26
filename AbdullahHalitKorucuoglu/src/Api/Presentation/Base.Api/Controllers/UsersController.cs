using Base.Api.Application.Interfaces.Services;
using Base.Api.Application.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Base.Api.Controllers;

public class UsersController : BaseApiController
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateUserRequest model)
    {
        return Result(await _service.Update(model));
    }

    [Authorize]
    [HttpPut("password")]
    public async Task<IActionResult> UpdatePassword(ChangePasswordRequest model)
    {
        return Result(await _service.ChangePassword(model));
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest model)
    {
        return Result(await _service.Login(model));
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest model)
    {
        return Result(await _service.Register(model));
    }

    [HttpGet("validate-mail")]
    public async Task<IActionResult> ValidateUserEmail(string userId, string token)
    {
        return Result(await _service.ValidateUserEmail(userId, token));
    }

    [HttpPost("resetpassword")]
    public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
    {
        return Result(await _service.ResetPassword(model));
    }

    [HttpPost("resetpassword-confirm")]
    public async Task<IActionResult> ResetPasswordConfirm(ResetPasswordConfirmRequest model)
    {
        return Result(await _service.ResetPasswordConfirm(model));
    }
}