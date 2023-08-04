using OnionArchitecture.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OnionArchitecture.Application.Abstractions.Storage;
using OnionArchitecture.Infrastructure.Services.Storage;
using DocumentFormat.OpenXml.Office2019.Drawing.Diagram11;
using OnionArchitecture.Infrastructure.Services.Storage.Azure;
using OnionArchitecture.Infrastructure.Services.Storage.Local;
using OnionArchitecture.Infrastructure.Enums;

namespace OnionArchitecture.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //serviceCollection.AddScoped<IFileService, FileService>();
            services.AddScoped<IStorageService, StorageService>();

        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:

                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }

    }
}
