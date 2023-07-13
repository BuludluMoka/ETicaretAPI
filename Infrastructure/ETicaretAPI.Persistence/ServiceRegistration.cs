using Microsoft.EntityFrameworkCore;

using OnionArchitecture.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Persistence.Repositories;
using OnionArchitecture.Application.Abstractions.Services.Project;
using OnionArchitecture.Persistence.Services.Project;
using Core.Application.Utilities.Settings;

namespace OnionArchitecture.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(AppSettings.Settings.AppDbConnectionModel.ToString()));
           
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IProductService, ProductService>();

        }
    }
}
