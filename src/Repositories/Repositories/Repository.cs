using DataAccess.Entities;
using System;
using System.Linq.Expressions;

namespace Business.Repositories
{
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected Repository()
        {
            
        }

        public Task Delete(Villa entity)
        {
            throw new NotImplementedException();
        }

        public Task<Villa> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Villa>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Villa> Get(Expression<Func<TEntity, bool>> predicate, bool tracked = true)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Villa entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
