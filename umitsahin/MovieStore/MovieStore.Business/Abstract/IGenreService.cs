using MovieStore.DTO.Response.Genre;

namespace MovieStore.Business.Abstract;

public interface IGenreService
{
    Task<GetGenreByIdDto> GetByIdAsync(int id);
    Task<List<GetGenresDto>> GetAllAsync();
}
