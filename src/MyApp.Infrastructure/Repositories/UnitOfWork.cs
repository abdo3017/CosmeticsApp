using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Repositories;
using MyApp.Infrastructure.Data;
using System.Data;
using System.Data.Entity;

namespace MyApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly MyAppDbContext _dbContext;
        private readonly IDictionary<Type, dynamic> _repositories;
        private bool _disposed;

        public UnitOfWork(MyAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<Type, dynamic>();
        }

        public IBaseRepository<T, TType> Repository<T, TType>() where T : BaseEntity
        {
            var entityType = typeof(T);

            if (_repositories.ContainsKey(entityType))
            {
                return _repositories[entityType];
            }

            var repositoryType = typeof(BaseRepository<,>);

            var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T), typeof(TType)), _dbContext);

            if (repository == null)
            {
                throw new NullReferenceException("Repository should not be null");
            }

            _repositories.Add(entityType, repository);

            return (IBaseRepository<T, TType>)repository;
        }



        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public dynamic BeginTransaction(IsolationLevel isolationLevel = default)
        {
            return _dbContext.Database.BeginTransaction(isolationLevel);
        }
        public async Task<dynamic> BeginTransactionAsync(IsolationLevel isolationLevel = default)
        {
            return await _dbContext.Database.BeginTransactionAsync(isolationLevel);
        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.CommitTransactionAsync(cancellationToken);
        }
        public void Rollback()
        {
            _dbContext.Database.RollbackTransaction();
        }
        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.RollbackTransactionAsync(cancellationToken);
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
                foreach (IDisposable repository in _repositories.Values)
                {
                    repository.Dispose();// dispose all repositries
                }
            }
            _disposed = true;
        }
        public int Complete()
        {
            throw new NotImplementedException();
        }

        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}