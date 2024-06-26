﻿using Business.Dtos.VillaDtos;
using Business.Repositories.ParentRepository;
using Business.ViewModels;
using DataAccess.Entities;

namespace Business.Repositories.VillaRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<List<VillaViewModel>> GetAsync();
        new Task<VillaViewModel> GetAsync(int id);
        void Insert(VillaCreateDto dto);
        Task UpdateAsync( VillaUpdateDto dto);
        Task DeleteAsync(int? id);
    }
}
