using Business.Dtos;
using Business.Repositories.ParentRepository;
using Business.ViewModels;
using DataAccess.Entities;

namespace Business.Repositories.VillaRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<VillaViewModel> GetAll();
        Task InsertAsync(VillaCreateDto dto);
        Task UpdateAsync(int id , VillaUpdateDto dto); 
        Task DeleteAsync(int id);
    }
}
