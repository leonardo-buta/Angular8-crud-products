using AutoMapper;
using Products.Domain.DTO;
using Products.Domain.Models;

namespace Products.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}
