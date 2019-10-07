using Products.Domain.Interfaces;
using Products.Infra.Data.Context;
using System.Threading.Tasks;

namespace Products.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MongoContext _context;

        public UnitOfWork(MongoContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
