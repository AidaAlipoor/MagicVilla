using DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Business.Repositories.ParentRepository
{
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        protected Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity) => _dbSet.Add(entity);

        public virtual void Update(TEntity entity) => _dbSet.Update(entity);

        public virtual void Delete(TEntity entity) => _dbSet.Remove(entity);

        public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> entities = _dbSet;

            if (filter is not null)
            {
                entities = _dbSet.Where(filter);
            }
            return entities.ToListAsync();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<TEntity> entities = _dbSet;

            if (filter is not null && tracked is false)
            {
                entities = entities.AsNoTracking();

                entities = _dbSet.Where(filter);
            }
            return entities.FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FindAsync();
        }

        public virtual async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
