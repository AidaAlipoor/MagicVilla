using DataAccess.Entities;
using System.Linq.Expressions;

namespace Business.Repositories
{
    internal abstract class Repository : IRepository
    {
        protected Repository()
        {
            
        }

        public Task Delete(Villa entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Villa>> Get(Expression<Func<Villa>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Villa> Get(Expression<Func<Villa>> filter, bool tracked = true)
        {
            throw new NotImplementedException();
        }

        public Task<Villa> Get(int id)
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
