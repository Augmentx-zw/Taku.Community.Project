using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Taku.Community.Project.Domain;

namespace Taku.Community.Project.Data
{

    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<TEntity> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where = null)
        {
            var query = Query(where);
            return await query.ToListAsync();

        }
        public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> where = null)
        {
            var query = Query(where);

            return await query.FirstOrDefaultAsync();
        }
        public virtual async Task<TEntity> GetByIDAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        private IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where = null)
        {
            IQueryable<TEntity> query = _dbSet;
            query = where != null ? query.Where(where) : query;
            return query;
        }

        public virtual void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }


    }
}