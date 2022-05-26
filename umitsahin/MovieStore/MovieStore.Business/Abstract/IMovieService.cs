using MovieStore.DTO.Request.Movie;
using MovieStore.DTO.Response;
using MovieStore.DTO.Response.Movie;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Abstract
{
    public interface IMovieService
    {
        Task<GetMovieByIdDto> GetByIdAsync(int id);
        Task<List<GetMoviesDto>> GetAllAsync();
        Task<GetMovieByIdDto> GetMovieDetailById(int id);
        Task<List<GetMoviesByNameDto>> GetMoviesByNameAsync(string key);
        Task<int> AddMovie(AddMovieDto addMovieDto);
        Task UpdateMovie(UpdateMovieDto updateMovieDto);
        Task DeleteMovie(int id);
        Task<bool> IsMovieExists(int id);
    }
}
