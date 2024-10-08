﻿using MagicVilla_Web.Models.Dtos.VillaDtos;

namespace MagicVilla_Web.Services.VillaNumberService
{
    public interface IVillaService 
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaCreateDto villaCreateDto);
        Task<T> UpdateAsync<T>(VillaUpdateDto villaUpdateDto);
        Task<T> DeleteAsync<T>(int id);

    }
}
