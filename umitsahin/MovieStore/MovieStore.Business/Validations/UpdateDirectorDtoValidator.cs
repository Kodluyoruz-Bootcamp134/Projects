using FluentValidation;
using MovieStore.DTO.Request.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validations
{
    public class UpdateDirectorDtoValidator:AbstractValidator<UpdateDirectorDto>
    {
        public UpdateDirectorDtoValidator()
        {
            RuleFor(x => x.Id)
             .InclusiveBetween(1, int.MaxValue).WithMessage("Geçersiz {PropertyName} alanı");
            RuleFor(x => x.DirectorName)
                   .NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez")
                   .NotNull().WithMessage("{PropertyName} alanı boş geçilemez");
        }
    }
}
