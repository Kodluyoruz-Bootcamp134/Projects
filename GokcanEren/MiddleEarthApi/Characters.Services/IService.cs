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
    public interface IService
    {
         public Task<IList<CharactersRespons>> GetAll();
        Task<CharactersRespons> GetById(int id);
        Task<IList<CharactersRespons>> GetByName(string name);
        Task<int> AddCharacter(AddCharacterRequest request);
        Task UpdateCharacter(UpdateCharacterRequest request);
        Task DeleteCharacter(int id);
        Task<bool> IsCharacterExist(int id);

    }
}
