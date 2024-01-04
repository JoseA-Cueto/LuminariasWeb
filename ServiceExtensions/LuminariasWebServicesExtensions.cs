using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Repositories;

namespace LuminariasWeb.sln.ServiceExtensions
{
    public static class LuminariasWebServicesExtensions
    {
        public static void AddLuminariasWebServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();//contenedor Dependencias
            services.AddScoped<IServicesService, ServicesService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
        }
    }
}
