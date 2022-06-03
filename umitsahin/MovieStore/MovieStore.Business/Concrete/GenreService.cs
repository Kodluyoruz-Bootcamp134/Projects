using AutoMapper;
using MovieStore.Business.Abstract;
using MovieStore.DataAccess.Repositories.Abstract;
using MovieStore.DTO.Request.Genre;
using MovieStore.DTO.Response.Genre;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Concrete
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddGenre(AddGenreDto addGenreDto)
        {
          var genre= _mapper.Map<Genre>(addGenreDto);
            await _repository.Add(genre);
            return genre.Id;
        }

        public async Task DeleteGenre(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<GetGenresDto>> GetAllAsync()
        {
            var genreList= await _repository.GetAllAsync();
            return _mapper.Map<List<GetGenresDto>>(genreList);
        }

        public async Task<GetGenreByIdDto> GetByIdAsync(int id)
        {
           var genre= await _repository.GetByIdAsync(id);
            return _mapper.Map<GetGenreByIdDto>(genre);
        }

        public async Task UpdateGenre(UpdateGenreDto updateGenreDto)
        {
           var genre = _mapper.Map<Genre>(updateGenreDto);
            await _repository.Update(genre);
        }
    }
}
