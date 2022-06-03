using MovieStore.DTO.Request.Genre;
using MovieStore.DTO.Response.Genre;

namespace MovieStore.Business.Abstract;

public interface IGenreService
{
    Task<GetGenreByIdDto> GetByIdAsync(int id);
    Task<List<GetGenresDto>> GetAllAsync();
    Task<int> AddGenre(AddGenreDto addGenreDto);
    Task UpdateGenre(UpdateGenreDto updateGenreDto);
    Task DeleteGenre(int id);
}
