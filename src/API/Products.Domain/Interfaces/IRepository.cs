using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(Guid id, UpdateDefinition<TEntity> update);
        void Remove(Guid id);
        Task<long> Count(FilterDefinition<TEntity> filter);
        void Delete(FilterDefinition<TEntity> filter);
    }
}
