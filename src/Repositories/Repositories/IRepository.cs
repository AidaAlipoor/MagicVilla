using DataAccess.Entities;
using System.Linq.Expressions;

namespace Business.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<Villa>> Get(Expression<Func<TEntity, bool>> filter = null);
        Task<Villa> Get(Expression<Func<TEntity, bool>> filter = null, bool tracked = true);
        Task<Villa> Get(int id);
        Task Insert(Villa entity);
        Task Delete(Villa entity);
        Task SaveChanges();
    }
}
