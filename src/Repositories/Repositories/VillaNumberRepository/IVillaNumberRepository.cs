using Business.Dtos.VillaNumberDtos;
using Business.Repositories.ParentRepository;
using Business.ViewModels;
using DataAccess.Entities;

namespace Business.Repositories.VillaNumberRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<List<VillaNumberViewModel>> GetAsync();
        void Insert(VillaNumberDto dto);
        Task UpdateAsync(int id, VillaNumberDto dto);
        Task DeleteAsync(int id);

    }
}
