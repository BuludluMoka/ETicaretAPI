using Microsoft.Extensions.DependencyInjection;

namespace OnionArchitecture.Application.Helpers
{
    public static class ServiceProviderHelper
    {
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceProvider == null)
                {
                    throw new InvalidOperationException("Service provider is not set. Call Create method first.");
                }
                return _serviceProvider;
            }
        }

        public static void Create(IServiceCollection services)
        {
            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
