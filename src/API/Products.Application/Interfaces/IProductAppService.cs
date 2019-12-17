using Products.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Application.Interfaces
{
    public interface IProductAppService
    {
        Task Add(ProductDto productDto);
        Task<IEnumerable<ProductDto>> GetAll();
    }
}
