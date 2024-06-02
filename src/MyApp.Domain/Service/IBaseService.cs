using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Service
{
    public interface IBaseService<T, TType> : IBaseService where T : BaseEntity
    {
        Task<T?> GetByIdAsync(TType id);
        Task<IList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(TType entityId);
        Task<dynamic> BeginTransactionAsync(IsolationLevel isolationLevel = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        void UpdateWithoutSave(T entity);
        T? GetById(TType id);
    }

}
