using AutoMapper;
using Business.Dtos.VillaNumberDtos;
using Business.Repositories.ParentRepository;
using Business.ViewModels;
using DataAccess;
using VillaNumberEntity = DataAccess.Entities.VillaNumber;

namespace Business.Repositories.VillaNumberRepository
{
    internal class VillaNumberRepository : Repository<VillaNumberEntity>, IVillaNumberRepository
    {
        private readonly IMapper _mapper;
        public VillaNumberRepository(ApplicationDbContext dbContext , IMapper mapper)
            : base(dbContext) => _mapper = mapper;


        public async Task<List<VillaNumberViewModel>> GetAsync()
        {
            var entities = await GetAllAsync(includeNavigationProperty : "Villa");

            return _mapper.Map<List<VillaNumberViewModel>>(entities);
        }

        public void Insert(VillaNumberDto dto)
        {
            var entity = _mapper.Map<VillaNumberEntity>(dto);

            CheckSpecialDetailsIsEmpty(entity.SpecialDetails);

            Insert(entity);
        }

        public async Task UpdateAsync(int id, VillaNumberDto dto)
        {
            await CheckIdExist(id);

            var entity = await base.GetAsync(id);

            var updatedEntity = _mapper.Map(dto , entity);

            CheckSpecialDetailsIsEmpty(updatedEntity.SpecialDetails);   

            Update(updatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await CheckIdExist(id);

            var entity = await GetAsync(id);

            Delete(entity);
        }


        private void CheckSpecialDetailsIsEmpty(string details)
        {
            if (string.IsNullOrEmpty(details))
                throw new Exception("Detail is empty");

        }
        private async Task CheckIdExist(int id)
        {
            var entity = await GetAsync(id);

            if (entity is null)
                throw new Exception("id does not exist");
        }

    }
}
