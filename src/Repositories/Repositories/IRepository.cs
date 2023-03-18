using DataAccess.Entities;
using System.Linq.Expressions;

namespace Business.Repositories
{
    public interface IRepository
    {
        Task<List<Villa>> Get(Expression<Func<Villa>> filter);
        Task<Villa> Get(Expression<Func<Villa>> filter, bool tracked = true);
        Task<Villa> Get(int id);
        Task Insert(Villa entity);
        Task Delete(Villa entity);
        Task SaveChanges();
    }
}
