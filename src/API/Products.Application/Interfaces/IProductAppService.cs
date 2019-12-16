using Products.Domain.DTO;
using System.Threading.Tasks;

namespace Products.Application.Interfaces
{
    public interface IProductAppService
    {
        Task Add(ProductDto productDto);
    }
}
