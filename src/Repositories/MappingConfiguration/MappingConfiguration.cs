using AutoMapper;
using Business.Dtos;
using Business.ViewModels;
using DataAccess.Entities;

namespace Business.MappingConfiguration
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Villa , VillaUpdateDto>().ReverseMap();
            CreateMap<Villa , VillaCreateDto>().ReverseMap();
            
            CreateMap<Villa , VillaViewModel>().ReverseMap();
            CreateMap<object , object>();

        }
    }
}
