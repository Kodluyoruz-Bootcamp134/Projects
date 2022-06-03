using FluentValidation;
using MovieStore.DTO.Request.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validations;

public class UpdateGenreDtoValidator:AbstractValidator<UpdateGenreDto>
{
    public UpdateGenreDtoValidator()
    {
        RuleFor(x => x.Id)
              .InclusiveBetween(1, int.MaxValue).WithMessage("Geçersiz {PropertyName} alanı");
        RuleFor(x => x.GenreName)
               .NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez")
               .NotNull().WithMessage("{PropertyName} alanı boş geçilemez");
    }
}
