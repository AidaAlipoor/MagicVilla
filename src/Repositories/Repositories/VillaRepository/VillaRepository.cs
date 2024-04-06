using AutoMapper;
using Business.Dtos.VillaDtos;
using Business.Repositories.ParentRepository;
using Business.ViewModels;
using DataAccess;
using VillaEntity = DataAccess.Entities.Villa;

namespace Business.Repositories.VillaRepository
{
    internal class VillaRepository : Repository<VillaEntity>, IVillaRepository
    {
        private readonly IMapper _mapper;
        public VillaRepository(ApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext) => _mapper = mapper;

        public async Task<List<VillaViewModel>> GetAsync()
        {
            var entities = await base.GetAllAsync();

            return _mapper.Map<List<VillaViewModel>>(entities);
        }

        public new async Task<VillaViewModel> GetAsync(int id)
        {
            var entity = await base.GetAsync(id);
            return _mapper.Map<VillaViewModel>(entity);
        }

        public void Insert(VillaCreateDto dto)
        {
            var entity = _mapper.Map<VillaEntity>(dto);

            ValidateEntity(entity, dto.Name);

            Insert(entity);
        }

        public async Task UpdateAsync(VillaUpdateDto dto)
        {
            await CheckIdExist(dto.Id);

            var entity = await base.GetAsync(dto.Id);

            var updatedEntity = _mapper.Map(dto, entity);

            ValidateEntity(updatedEntity, dto.Name);

            Update(updatedEntity);
        }

        public async Task DeleteAsync(int? id)
        {
            await CheckIdExist(id ?? default);

            var entity = await base.GetAsync(id ?? default);

            Delete(entity);
        }



        private void ValidateEntity(VillaEntity entity, string name)
        {
            CheckNameAndDetailAreEmpty(entity.Name, entity.Detail);
            CheckNameAndDetailAreLetter(entity.Name, entity.Detail);
        }


        private async Task CheckIfVillaExist(int id, string name)
        {
            await CheckIdExist(id);

            var entity = await GetAsync(id);

            if (entity.Name == name)
                throw new Exception("Villa is already exist!");
        }
        private void CheckNameAndDetailAreLetter(string name, string detail)
        {
            if (int.TryParse(name, out _)
                || int.TryParse(detail, out _))
                throw new Exception("Name or Detail is invalid");
        }
        private void CheckNameAndDetailAreEmpty(string name, string detail)
        {
            if (string.IsNullOrEmpty(name)
                || string.IsNullOrEmpty(detail))
                throw new Exception("Name or Detail is empty");

        }
        private async Task CheckIdExist(int id)
        {
            var entity = await GetAsync(id);

            if (entity is null)
                throw new Exception("id does not exist");
        }
    }
}
