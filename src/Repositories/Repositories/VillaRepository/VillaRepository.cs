using AutoMapper;
using Business.Dtos;
using Business.Repositories.ParentRepository;
using Business.ViewModels;
using VillaEntity = DataAccess.Entities.Villa;

namespace Business.Repositories.VillaRepository
{
    internal class VillaRepository : Repository<VillaEntity>, IVillaRepository
    {
        private readonly IMapper _mapper;
        public VillaRepository(ApplicationDbContext dbContext , IMapper mapper) 
            : base(dbContext) => _mapper = mapper;

        public async Task<List<VillaViewModel>> GetAsync()
        {
            var entities = await base.GetAllAsync();

            var records = _mapper.Map<List<VillaViewModel>>(entities);

            return records; 
        }

        public void Insert(VillaCreateDto dto)
        {
            var entity = _mapper.Map<VillaEntity>(dto);

            Insert(entity);
        }

        public async Task UpdateAsync(int id, VillaUpdateDto dto)
        {
            var entity = GetAsync(id);

            var updatedEntity = _mapper.Map<VillaEntity>(dto);

            Update(updatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);

            Delete(entity);
        }
    }
}
