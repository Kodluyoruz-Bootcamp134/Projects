using Base.Api.Application.Models.Dtos;
using Base.Api.Application.Models.Users;
using System.Threading.Tasks;

namespace Base.Api.Application.Interfaces.Services;

public interface IUserService
{
    Task<Response<string>> Login(LoginRequest model);

    Task<Response<NoContent>> Register(RegisterRequest model);

    Task<Response<NoContent>> ValidateUserEmail(string userId, string token);

    Task<Response<NoContent>> ResetPassword(ResetPasswordRequest model);

    Task<Response<NoContent>> ResetPasswordConfirm(ResetPasswordConfirmRequest model);

    Task<Response<NoContent>> Update(UpdateUserRequest model);

    Task<Response<NoContent>> ChangePassword(ChangePasswordRequest model);
}