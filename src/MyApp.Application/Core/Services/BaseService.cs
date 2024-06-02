using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Core.Services
{
    public class BaseService<T, TType> : IBaseService<T,TType> where T : BaseEntity
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        protected readonly IBaseRepository<T,TType> _repository;
        private bool _disposed;

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _repository = UnitOfWork.Repository<T, TType>();
        }

        public async Task<T?> GetByIdAsync(TType id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public T? GetById(TType id)
        {
            return  _repository.GetById(id);
        }
        public async Task<IList<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            var addedEntity = await _repository.AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            return addedEntity;
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            UnitOfWork.SaveChanges();
        }
        public void UpdateWithoutSave(T entity)
        {
            _repository.Update(entity);
        }
        public void Delete(T entity)
        {
            _repository.Delete(entity);
            UnitOfWork.SaveChanges();
        }

        public void DeleteById(TType entityId)
        {
            _repository.DeleteById(entityId);
            UnitOfWork.SaveChanges();
        }
        public async Task<dynamic> BeginTransactionAsync(IsolationLevel isolationLevel = default)
        {
            return await UnitOfWork.BeginTransactionAsync(isolationLevel);
        }
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await UnitOfWork.CommitAsync(cancellationToken);
        }
        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await UnitOfWork.RollbackAsync(cancellationToken);
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
                UnitOfWork.Dispose();
            }
            _disposed = true;
        }
    }
}
