using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Core.Services
{
    public class BaseService<TEntity, TType> : IBaseService<TEntity,TType> where TEntity : BaseEntity
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        protected readonly IBaseRepository<TEntity,TType> _repository;
        private bool _disposed;

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _repository = UnitOfWork.Repository<TEntity, TType>();
        }

        public async Task<TEntity?> GetByIdAsync(TType id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = await _repository.AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            return addedEntity;
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
            UnitOfWork.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            UnitOfWork.SaveChanges();
        }

        public void DeleteById(TType entityId)
        {
            _repository.DeleteById(entityId);
            UnitOfWork.SaveChanges();
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
