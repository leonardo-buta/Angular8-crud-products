using AutoMapper;
using Products.Application.Interfaces;
using Products.Domain.DTO;
using Products.Domain.Interfaces;
using Products.Domain.Models;
using System;
using System.Collections.Generic;
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
            var product = _mapper.Map<Product>(productDto);
            product.CreationDate = DateTime.Now;
            product.Active = true;

            _productRepository.Add(product);
            await _uow.Commit();
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var results = _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetAll());
            return results;
        }

        public async Task<ProductDto> GetById(Guid id)
        {
            var result = _mapper.Map<ProductDto>(await _productRepository.GetById(id));
            return result;
        }
    }
}
