using AutoMapper;
using Products.Application.Interfaces;
using Products.Domain;
using Products.Domain.DTO;
using Products.Domain.Interfaces;
using Products.Domain.Models;
using System.Threading.Tasks;

namespace Products.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;        

        public ProductAppService(IUnitOfWork uow, IMapper mapper, IProductRepository productRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task Add(ProductDto productDto)
        {
            _productRepository.Add(_mapper.Map<Product>(productDto));
            await _uow.Commit();
        }
    }
}
