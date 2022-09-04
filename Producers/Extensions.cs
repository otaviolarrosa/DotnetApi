using Microsoft.Extensions.DependencyInjection;
using StreamNet;

namespace Producers
{
    public static class Extensions
    {
        public static IServiceCollection AddProducers(this IServiceCollection services)
        {
            services.AddProducer();
            return services;
        }
    }
}