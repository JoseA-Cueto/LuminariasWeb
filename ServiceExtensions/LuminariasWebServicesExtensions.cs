using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Interface;
using LuminariasWeb.sln.Repositories;
using LuminariasWeb.sln.Services;

namespace LuminariasWeb.sln.ServiceExtensions
{
    public static class LuminariasWebServicesExtensions
    {
        public static void AddLuminariasWebServices(this IServiceCollection services)
        {
            // Contenedor de dependencias

            // Product
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            // Service
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServicesService, ServicesService>();

            // User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
