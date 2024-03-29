﻿using System.Linq.Expressions;

namespace Business.Repositories.ParentRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true);
        Task<TEntity> GetAsync(int id);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        Task SaveChangesAsync();
    }
}
