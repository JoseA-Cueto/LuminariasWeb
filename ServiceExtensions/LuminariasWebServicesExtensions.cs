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

            // Logger
            services.AddScoped<ILogger, ConsoleLogger>();

            // Product
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            // Service
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceService, ServiceService>();

            // User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            // Category
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            // Cart
            services.AddScoped<ICartService, CartService>();
             //ImageFile
            services.AddScoped<IImageFileService, ImageFileService>();
            services.AddScoped<IImageFileRepository, ImageFileRepository>();
            //Encryption
            services.AddScoped<IEncryptionService, EncryptionService>();
                
        }
    }

}
