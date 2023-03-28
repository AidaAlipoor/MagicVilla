using AutoMapper;
using Business.Dtos;
using Business.Repositories.ParentRepository;
using Business.ViewModels;
using VillaEntity = DataAccess.Entities.Villa;

namespace Business.Repositories.VillaRepository
{
    internal class VillaRepository : Repository<VillaEntity>, IVillaRepository
    {
        private readonly IMapper _Mapper;
        public VillaRepository(ApplicationDbContext dbContext , IMapper mapper) 
            : base(dbContext) => _Mapper = mapper;

        public async Task<VillaViewModel> GetAllAsync()
        {
            var entities = await base.GetAsync(null , false);

            return _Mapper.Map<VillaViewModel>(entities);
        }

        public void Insert(VillaCreateDto dto)
        {
            var entity = _Mapper.Map<VillaEntity>(dto);

            Insert(entity);
        }

        public Task UpdateAsync(int id, VillaUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);

            Delete(entity);
        }
    }
}
