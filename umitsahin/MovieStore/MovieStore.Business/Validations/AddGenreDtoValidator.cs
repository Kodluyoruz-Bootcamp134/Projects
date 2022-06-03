using FluentValidation;
using MovieStore.DTO.Request.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validations;

public class AddGenreDtoValidator : AbstractValidator<AddGenreDto>
{
    public AddGenreDtoValidator()
    {
        RuleFor(x => x.GenreName)
               .NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez")
               .NotNull().WithMessage("{PropertyName} alanı boş geçilemez");
    }
  
}
