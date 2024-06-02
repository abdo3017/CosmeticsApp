using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Data;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Repositories;

namespace MyApp.Infrastructure.Repositories
{
    public class BaseRepository<T, TType> : IBaseRepository<T, TType> where T : BaseEntity
    {
        protected readonly MyAppDbContext _dbContext;
        private bool _disposed;

        public BaseRepository(MyAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync(TType id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public T? GetById(TType id)
        {
            return  _dbContext.Set<T>().Find(id);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(ISpecification<T> spec)
        {

            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<T?> FirstOrDefaultNoTrackingAsync(ISpecification<T> spec)
        {

            return await ApplySpecification(spec).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<bool> AnyAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).AnyAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void DeleteById(TType entityID)
        {
            var entity = _dbContext.Set<T>().Find(entityID);
            _dbContext.Set<T>().Remove(entity);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }
    }
}
