using AutoMapper;
using Characters.DTO.Requests;
using Characters.DTO.Responses;
using Characters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.Services.Mapping
{
    public class CharacterMap : Profile
    {
        public CharacterMap()
        {
            CreateMap<Character, CharactersRespons>();
            CreateMap<AddCharacterRequest, Character>();
            CreateMap<UpdateCharacterRequest, Character>();
        }
    }
}
