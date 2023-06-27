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

        public async Task<List<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter)
            => await _dbSet.Where(filter).ToListAsync();

        public async Task<TEntity> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<TEntity> entities = _dbSet;

            if (filter is not null && tracked is false)
            {
                entities.AsNoTracking();

                entities = _dbSet.Where(filter);
            }
            return await entities.FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id) => await _dbSet.FindAsync(id);
       

        public virtual async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
