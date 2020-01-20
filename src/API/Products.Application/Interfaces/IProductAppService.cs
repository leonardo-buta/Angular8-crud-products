using Products.Domain.DTO;
using Products.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Application.Interfaces
{
    public interface IProductAppService
    {
        Task Add(ProductDto productDto);
        Task<PaginationResultDTO<ProductDto>> Filter(ProductParameters parameters);
        Task<ProductDto> GetById(Guid id);
        Task<bool> Update(Guid id, ProductDto productDto);
        Task Delete(Guid id);
    }
}
