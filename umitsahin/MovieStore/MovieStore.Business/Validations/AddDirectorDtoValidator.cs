using FluentValidation;
using MovieStore.DTO.Request.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validations
{
    public class AddDirectorDtoValidator:AbstractValidator<AddDirectorDto>
    {
        public AddDirectorDtoValidator()
        {
            RuleFor(x => x.DirectorName)
                  .NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez")
                  .NotNull().WithMessage("{PropertyName} alanı boş geçilemez");
        }
    }
}
