using AutoMapper;
using MovieStore.Business.Abstract;
using MovieStore.DataAccess.Repositories.Abstract;
using MovieStore.DTO.Request.Movie;
using MovieStore.DTO.Response.Movie;
using MovieStore.Entities;

namespace MovieStore.Business.Concrete;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;
    private readonly IMapper _mapper;
    public MovieService(IMovieRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> AddMovie(AddMovieDto addMovieDto)
    {
        var movie = _mapper.Map<Movie>(addMovieDto);
        await _repository.Add(movie);
        return movie.Id;

    }

    public async Task DeleteMovie(int id)
    {
        await _repository.Delete(id);
    }

    public async Task<List<GetMoviesDto>> GetAllAsync()
    {
        var movieList = await _repository.GetAllAsync();
        return _mapper.Map<List<GetMoviesDto>>(movieList);

    }

    public async Task<GetMovieByIdDto> GetByIdAsync(int id)
    {
        var movie = await _repository.GetByIdAsync(id);
        return _mapper.Map<GetMovieByIdDto>(movie);
    }
    public async Task<GetMovieByIdDto> GetMovieDetailById(int id)
    {
        

        return await _repository.GetMovieDetailById(id);
    }

    public async Task<List<GetMoviesByNameDto>> GetMoviesByNameAsync(string key)
    {
        var result = await _repository.GetMoviesByNameAsync(key);
        return _mapper.Map<List<GetMoviesByNameDto>>(result);

    }

    public async Task<bool> IsMovieExists(int id)
    {
        return await _repository.AnyAsync(id);
    }

    public async Task UpdateMovie(UpdateMovieDto updateMovieDto)
    {
        var movie = _mapper.Map<Movie>(updateMovieDto);
        await _repository.Update(movie);
    }
}
