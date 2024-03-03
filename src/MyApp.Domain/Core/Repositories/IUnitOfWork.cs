using MyApp.Domain.Core.Models;
using System.Data;
using System.Diagnostics;

namespace MyApp.Domain.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Dispose(bool disposing);
        int Complete();
        Task<int> CompleteAsync();
        dynamic BeginTransaction(IsolationLevel isolationLevel = default);
        Task<dynamic> BeginTransactionAsync(IsolationLevel isolationLevel = default);
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Rollback();
        Task RollbackAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        IBaseRepository<T, TType> Repository<T, TType>() where T : BaseEntity;
    }
}