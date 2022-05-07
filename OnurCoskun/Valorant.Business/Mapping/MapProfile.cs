using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valorant.DTO.Requests;
using Valorant.DTO.Responses;
using Valorant.Entities;

namespace Valorant.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Agent, AgentDisplayResponse>();
            CreateMap<AddAgentRequest, Agent>();
        }
    }
}
