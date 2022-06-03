using AutoMapper;
using MovieStore.Business.Abstract;
using MovieStore.DataAccess.Repositories.Abstract;
using MovieStore.DTO.Request.Director;
using MovieStore.DTO.Response.Director;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Concrete;

public class DirectorService : IDirectorService
{
    private readonly IDirectorRepository _repository;
    private readonly IMapper _mapper;

    public DirectorService(IDirectorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> AddDirector(AddDirectorDto addDirectorDto)
    {
        var director = _mapper.Map<Director>(addDirectorDto);
        await _repository.Add(director);
        return director.Id;
    }

    public async Task DeleteDirector(int id)
    {
       await _repository.Delete(id);
    }

    public async Task<List<GetDirectorsDto>> GetAllAsync()
    {
        var directorList = await _repository.GetAllAsync();
        return _mapper.Map<List<GetDirectorsDto>>(directorList);
    }

    public async Task<GetDirectorByIdDto> GetByIdAsync(int id)
    {
        var director = await _repository.GetByIdAsync(id);
        return _mapper.Map<GetDirectorByIdDto>(director);
    }

    public async Task UpdateDirector(UpdateDirectorDto updateDirectorDto)
    {
        var director = _mapper.Map<Director>(updateDirectorDto);
        await _repository.Update(director);
    }
}
