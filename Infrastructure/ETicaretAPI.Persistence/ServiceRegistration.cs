using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Abstractions.DB;
using OnionArchitecture.Application.Abstractions.DB.Tools;
using OnionArchitecture.Application.Abstractions.Services.Project;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Application.Repositories.FileUploadRepo;
using OnionArchitecture.Persistence.Contexts;
using OnionArchitecture.Persistence.Repositories;
using OnionArchitecture.Persistence.Repositories.FileUploadRepo;
using OnionArchitecture.Persistence.Services.Project;

namespace OnionArchitecture.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("PostgreSqlConnection")));


            //Other
            services.AddScoped<IApplicationDbContext, AppDbContext>();
            services.AddScoped<IEFDatabaseTool, EfDatabaseTool>();

            //Repositories
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();


            //Services
            //services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<IProductService, ProductService>();




        }

    }
}
