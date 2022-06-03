using FluentValidation;
using MovieStore.DTO.Request.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validations
{
    public class AddMovieDtoValidator:AbstractValidator<AddMovieDto>
    {
        public AddMovieDtoValidator()
        {
            RuleFor(x=>x.MovieName)
                .NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez")
                .NotNull().WithMessage("{PropertyName} alanı boş geçilemez");

            RuleFor(x => x.Price)
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} alanı 0'dan büyük olmalıdır");
            RuleFor(x => x.GenreId)
              .InclusiveBetween(1, int.MaxValue).WithMessage("Geçersiz {PropertyName} alanı");
            RuleFor(x => x.DirectorId)
              .InclusiveBetween(1, int.MaxValue).WithMessage("Geçersiz {PropertyName} alanı");
        }
    }
}
