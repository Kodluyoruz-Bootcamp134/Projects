using MovieStore.DTO.Response.Movie;
using MovieStore.Entities;

namespace MovieStore.DataAccess.Repositories.Abstract;

public interface IMovieRepository:IRepository<Movie>
{
    Task<GetMovieByIdDto> GetMovieDetailById(int id);
    Task<List<Movie>> GetMoviesByNameAsync(string key);
}

