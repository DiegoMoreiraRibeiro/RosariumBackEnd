using Microsoft.EntityFrameworkCore;
using RosariumBackEnd.Domain.Interfaces;

namespace RosariumBackEnd.Domain.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        protected BaseRepository(DbContext context)
        {
            try
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _dbSet = _context.Set<T>();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            try
            {
                IQueryable<T> result = _dbSet.AsQueryable();
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> GetByIdAsync(long id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteAsync(long id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
