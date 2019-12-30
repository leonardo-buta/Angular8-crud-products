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
        void Update(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update);
        void Delete(FilterDefinition<TEntity> filter);
        Task<long> Count(FilterDefinition<TEntity> filter);        
    }
}
