using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.AutoMapper;

namespace Products.API.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductsAPI.Startup));
            AutoMapperConfig.RegisterMappings();
        }
    }
}
