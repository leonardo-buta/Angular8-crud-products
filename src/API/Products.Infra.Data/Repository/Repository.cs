using MongoDB.Driver;
using MongoDB.Driver.Linq;
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

        public virtual void Delete(FilterDefinition<TEntity> filter) => _context.AddCommand(async () => await _dbSet.DeleteOneAsync(filter));

        public virtual async Task<TEntity> GetById(Guid id) => (await _dbSet.FindAsync<TEntity>(Builders<TEntity>.Filter.Eq("_id", id))).FirstOrDefault();

        public virtual async Task<IEnumerable<TEntity>> GetAll() => (await _dbSet.FindAsync(Builders<TEntity>.Filter.Empty)).ToList();

        public virtual IMongoQueryable<TEntity> GetAllAsQueryable() => _dbSet.AsQueryable(new AggregateOptions() { Collation = new Collation("en") });

        public virtual void Update(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update) => _context.AddCommand(async () => await _dbSet.UpdateOneAsync(filter, update));

        public virtual async Task<long> Count(FilterDefinition<TEntity> filter) => await _dbSet.CountDocumentsAsync(filter);

        public void Dispose() => _context?.Dispose();
    }
}
