using API.Dtos.Entities;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Game, GameDto>()
                .ForMember(x => x.ResourceUrl, o => o.MapFrom<ResourceUrlResolver>());

            CreateMap<Session, SessionDto>();
        }
    }
}
