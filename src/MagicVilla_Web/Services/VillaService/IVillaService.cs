using MagicVilla_Web.Models.Dtos.VillaDtos;

namespace MagicVilla_Web.Services.VillaService
{
    public interface IVillaService 
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaCreateDto villaCreateDto);
        Task<T> UpdateAsync<T>(int Id, VillaUpdateDto villaUpdateDto);
        Task<T> DeleteAsync<T>(int id);

    }
}
