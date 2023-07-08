using AutoMapper;
using Business.Dtos.VillaDtos;
using Business.Dtos.VillaNumberDtos;
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

            CreateMap<VillaNumber , VillaNumberViewModel>().ReverseMap();
            CreateMap<VillaNumber , VillaNumberDto>().ReverseMap();   
        }
    }
}
