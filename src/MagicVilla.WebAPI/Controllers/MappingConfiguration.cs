using AutoMapper;
using Business.Dtos;
using DataAccess.Entities;

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
