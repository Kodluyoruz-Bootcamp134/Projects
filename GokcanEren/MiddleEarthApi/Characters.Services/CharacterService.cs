using AutoMapper;
using Characters.Dal.Repository;
using Characters.DTO.Requests;
using Characters.DTO.Responses;
using Characters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.Services
{
    public class CharacterService:IService
    {
        private readonly IMapper mapper;
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
        {
            this.mapper = mapper;
            _characterRepository = characterRepository;
        }

        public async Task<int> AddCharacter(AddCharacterRequest request)
        {
            var character = mapper.Map<Character>(request);
            await _characterRepository.Add(character);
            return character.Id;
        }

        public async Task DeleteCharacter(int id)
        {
            await _characterRepository.Delete(id);
        }

        public async Task<IList<CharactersRespons>> GetAll()
        {
            var characters = await _characterRepository.GetAll();
            var result = mapper.Map<IList<CharactersRespons>>(characters);
            return result;
        }

        public async Task<CharactersRespons> GetById(int id)
        {
            var character=await _characterRepository.GetById(id);
            var result = mapper.Map<CharactersRespons>(character);
            return result;
        }

        public async Task<IList<CharactersRespons>> GetByName(string name)
        {
            var character=await _characterRepository.GetByName(name);
            var result = mapper.Map<IList<CharactersRespons>>(character);
            return result;
        }

        public async Task<bool> IsCharacterExist(int id)
        {
            return await _characterRepository.IsExist(id);
        }

        public async Task UpdateCharacter(UpdateCharacterRequest request)
        {
            var character = mapper.Map<Character>(request);
            await _characterRepository.Update(character);
        }
    }
}
