using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Infra.Data.Context
{
    public class MongoContext
    {
        private IMongoDatabase Database { get; set; }
        private IClientSessionHandle Session { get; set; }
        private MongoClient MongoClient { get; set; }        
        private readonly List<Func<Task>> _commands;

        public MongoContext(IConfiguration configuration)
        {            
            _commands = new List<Func<Task>>();
            MongoClient = new MongoClient(configuration.GetConnectionString("MongoConnection"));
            Database = MongoClient.GetDatabase(configuration.GetConnectionString("MongoDatabaseName"));
        }

        public async Task<int> SaveChanges()
        {
            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);
                await Session.CommitTransactionAsync();
            }

            return _commands.Count;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
