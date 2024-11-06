using AutoMapper;
using MagicVilla_Web.Models.Dtos.VillaDtos;
using MagicVilla_Web.Models.Dtos.VillaNumberDtos;
using MagicVilla_Web.Models.ViewModels.villaNumberViewModels;
using MagicVilla_Web.Models.ViewModels.VillaViewModels;

namespace Business.MappingConfiguration
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<VillaDto, VillaUpdateDto>().ReverseMap();
            CreateMap<VillaDto, VillaCreateDto>().ReverseMap();
            CreateMap<VillaDto, VillaViewModel>().ReverseMap();
            CreateMap<VillaViewModel, VillaUpdateDto>().ReverseMap();

            CreateMap<VillaNumDto , VillaNumberViewModel>().ReverseMap();
            CreateMap<VillaNumDto, VillaNumberDto>().ReverseMap();
        }
    }
}
