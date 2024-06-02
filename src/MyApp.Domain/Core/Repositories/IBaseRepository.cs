using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Specifications;

namespace MyApp.Domain.Core.Repositories
{
    public interface IBaseRepository<T,TType> : IDisposable where T : BaseEntity
    {
        Task<T?> GetByIdAsync(TType id);
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> ListAsync(ISpecification<T> spec);
        Task<T?> FirstOrDefaultAsync(ISpecification<T> spec);
        Task<T?> FirstOrDefaultNoTrackingAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(TType entityID);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<bool> AnyAsync(ISpecification<T> spec);
        T? GetById(TType id);
    }
}
