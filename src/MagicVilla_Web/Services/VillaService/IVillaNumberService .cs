using MagicVilla_Web.Models.Dtos.VillaDtos;
using MagicVilla_Web.Models.Dtos.VillaNumberDtos;

namespace MagicVilla_Web.Services.VillaNumberService
{
    public interface IVillaNumberService 
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaNumDto villaCreateDto);
        Task<T> UpdateAsync<T>(VillaNumberDto villaUpdateDto);
        Task<T> DeleteAsync<T>(int id);

    }
}
