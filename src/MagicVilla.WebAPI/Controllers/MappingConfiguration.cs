using AutoMapper;
using DataAccess.Entities;
using WebAPI.Controllers.Dtos;

namespace MagicVilla.WebAPI
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Villa , VillaUpdateDto>().ReverseMap();
            CreateMap<Villa , VillaCreateDto>().ReverseMap();   

        }
    }
}
