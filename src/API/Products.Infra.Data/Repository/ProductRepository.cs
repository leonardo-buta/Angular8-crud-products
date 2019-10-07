using Products.Domain.Interfaces;
using Products.Domain.Models;
using Products.Infra.Data.Context;

namespace Products.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MongoContext context) : base(context)
        {
        }
    }
}
