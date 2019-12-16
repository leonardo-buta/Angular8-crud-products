using AutoMapper;
using Products.Domain.DTO;
using Products.Domain.Models;

namespace Products.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
