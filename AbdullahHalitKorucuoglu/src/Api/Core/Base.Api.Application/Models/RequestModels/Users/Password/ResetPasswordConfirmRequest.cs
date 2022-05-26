namespace Base.Api.Application.Models.Users;

public class ResetPasswordConfirmRequest
{
    public string UserId { get; set; }
    public string Token { get; set; }
    public string NewPassword { get; set; }
}