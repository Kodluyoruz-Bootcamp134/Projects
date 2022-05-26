using AutoMapper;
using DataAccess.Repositories;
using DataTransferObject.Requests;
using DataTransferObject.Responses;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ClassService : IClassService
    {
        public readonly IMapper mapper;
        public readonly IClassRepository classRepository;

        public ClassService(IMapper mapper, IClassRepository classRepository)
        {
            this.mapper = mapper;
            this.classRepository = classRepository;
        }

        public async Task<IList<ClassDisplayResponses>> GetClasses()
        {
            var classes = await classRepository.GetAll();
            var result = mapper.Map<IList<ClassDisplayResponses>>(classes);
            return result;
        }

        public async Task<IList<ClassDisplayResponses>> GetClassesByName(string name)
        {
            var classes = await classRepository.GetClassesByName(name);
            var result = mapper.Map<IList<ClassDisplayResponses>>(classes);
            return result;
        }

        public async Task<IList<ClassDisplayResponses>> GetPokemonThisClass(string name)
        {
            var classes = await classRepository.GetPokemonThisClass(name);
            return classes;
        }

        public async Task DeleteClass(int id)
        {
            await classRepository.Delete(id);
        }

        public async Task<int> AddClass(AddClassRequest request)
        {
            if (!await classRepository.Any(x=> x.Name == request.Name))
            {
                var type = mapper.Map<Class>(request);
                await classRepository.Add(type);
                return type.Id;
            }
            return 0;

        }

        public async Task<ClassDisplayResponses> GetClassById(int id)
        {
            var type = await classRepository.GetById(id);
            var result = mapper.Map<ClassDisplayResponses>(type);
            return result;
        }
    }
}
