using Business.Dtos;
using Business.Repositories.ParentRepository;
using Business.ViewModels;
using DataAccess.Entities;

namespace Business.Repositories.VillaRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<VillaViewModel> GetAllAsync();
        void Insert(VillaCreateDto dto);
        Task UpdateAsync(int id , VillaUpdateDto dto); 
        Task DeleteAsync(int id);
    }
}
