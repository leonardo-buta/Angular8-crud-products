using Products.Application.Interfaces;
using Products.Domain;
using Products.Domain.Interfaces;
using Products.Domain.Models;
using System.Threading.Tasks;

namespace Products.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IUnitOfWork _uow;
        private readonly IProductRepository _productRepository;        

        public ProductAppService(IProductRepository productRepository, IUnitOfWork uow)
        {
            _uow = uow;
            _productRepository = productRepository;
        }

        public async Task Add(ProductDto product)
        {
            _productRepository.Add(new Product());
            await _uow.Commit();
        }
    }
}
