using MongoDB.Driver;
using Products.Domain.Interfaces;
using Products.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MongoContext _context;
        protected readonly IMongoCollection<TEntity> _dbSet;

        public Repository(MongoContext context)
        {
            _context = context;
            _dbSet = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual void Add(TEntity obj) => _context.AddCommand(async () => await _dbSet.InsertOneAsync(obj));

        public virtual void Remove(Guid id) => _context.AddCommand(() => _dbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var data = await _dbSet.FindAsync<TEntity>(Builders<TEntity>.Filter.Eq("_id", id));
            return data.FirstOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var data = await _dbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return data.ToList();
        }

        public virtual void Update(Guid id, UpdateDefinition<TEntity> update)
        {
            _context.AddCommand(() => _dbSet.UpdateOneAsync(Builders<TEntity>.Filter.Eq("_id", id), update));
        }

        public virtual async Task<long> Count(FilterDefinition<TEntity> filter)
        {
            var count = await _dbSet.CountDocumentsAsync(filter);
            return count;
        }

        public virtual void Delete(FilterDefinition<TEntity> filter)
        {
            _context.AddCommand(() => _dbSet.DeleteOneAsync(filter));
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
