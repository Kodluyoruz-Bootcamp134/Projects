using AutoMapper;
using DataTransferObject.Requests;
using DataTransferObject.Responses;
using Entities;

namespace Business.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AddPokemonRequest, Pokemon>();
            CreateMap<Pokemon, PokemonDisplayResponses>();
            CreateMap<UpdatePokemonRequest, Pokemon>();
        }
    }
}
