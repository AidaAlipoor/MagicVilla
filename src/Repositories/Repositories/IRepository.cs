﻿using DataAccess.Entities;
using System.Linq.Expressions;

namespace Business.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, bool tracked = true);
        Task<TEntity> GetAsync(int id);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        Task SaveChangesAsync();
    }
}
