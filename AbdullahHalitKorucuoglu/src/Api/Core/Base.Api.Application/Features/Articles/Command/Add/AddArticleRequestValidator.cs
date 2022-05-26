using FluentValidation;

namespace Base.Api.Application.Features.Articles;

public class AddArticleRequestValidator : AbstractValidator<AddArticleRequest>
{
    public AddArticleRequestValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("{PropertyName} alanı boş olamaz");
        RuleFor(x => x.Content).NotNull().NotEmpty().WithMessage("{PropertyName} alanı boş olamaz");
        RuleFor(x => x.CategoryId).NotNull().NotEmpty().WithMessage("{PropertyName} alanı boş olamaz");
    }
}