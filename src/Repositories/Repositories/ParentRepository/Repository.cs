using DataAccess;
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
            _dbContext.VillaNumbers
                .Include(v => v.Villa)
                .ToList();
        }

        public virtual void Insert(TEntity entity) => _dbSet.Add(entity);

        public virtual void Update(TEntity entity) => _dbSet.Update(entity);

        public virtual void Delete(TEntity entity) => _dbSet.Remove(entity);

        public async Task<List<TEntity>> GetAllAsync(string? includeNavigationProperty = null)
        {
            IQueryable<TEntity> entities = _dbSet;

            if (includeNavigationProperty is not null)
            {
                var properties = includeNavigationProperty
                    .Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (var property in properties)
                    entities = entities.Include(property);
            }

            return await entities.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter,
            string? includeNavigationProperty)
        {
            IQueryable<TEntity> entities = _dbSet;

            if (includeNavigationProperty is not null)
            {
                var properties = includeNavigationProperty
                    .Split(new char[] { ',' }, 
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (var property in properties)
                    entities = entities.Include(property);
            }

            return await entities.Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null,
            bool tracked = true, string? includeNavigationProperty = null)
        {
            IQueryable<TEntity> entities = _dbSet;

            if (filter is not null && tracked is false)
            {
                entities.AsNoTracking();

                entities = _dbSet.Where(filter);

                if(includeNavigationProperty is not null)
                {
                    var properties = includeNavigationProperty
                        .Split(new char[] { ',' },
                        StringSplitOptions.RemoveEmptyEntries);

                    foreach (var property in properties)
                        entities = entities.Include(property);
                }
            }
            return await entities.ToListAsync(); //TODO: Something wrong with this output and the method name :|
        }

        public virtual async Task<TEntity> GetAsync(int id) => await _dbSet.FindAsync(id);
       

        public virtual async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
