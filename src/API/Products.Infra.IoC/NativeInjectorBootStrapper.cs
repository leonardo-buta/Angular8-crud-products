using Microsoft.Extensions.DependencyInjection;
using Products.Application.Interfaces;
using Products.Application.Services;
using Products.Domain.Interfaces;
using Products.Infra.Data.Context;
using Products.Infra.Data.Repository;

namespace Products.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Context
            services.AddScoped<MongoContext>();

            // Application
            services.AddScoped<IProductAppService, ProductAppService>();

            // Infra
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
