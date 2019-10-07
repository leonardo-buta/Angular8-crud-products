using Products.Domain;
using System.Threading.Tasks;

namespace Products.Application.Interfaces
{
    public interface IProductAppService
    {
        Task Add(ProductDto product);
    }
}
