using Base.Api.Application.Models.Users;
using FluentValidation;

namespace Base.Api.Application.Validator.User;

public class ChangePasswordModelValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordModelValidator()
    {
        RuleFor(x => x.CurrentPassword).NotEmpty().NotNull().WithMessage("Güncel şifreniz boş olamaz");
        RuleFor(x => x.NewPassword).NotEmpty().NotNull().WithMessage("Yeni şifreniz boş olamaz");
        RuleFor(x => x.CurrentPassword).NotEqual(x => x.NewPassword).WithMessage("Yeni şifreniz eskisiyle aynı olamaz");
    }
}