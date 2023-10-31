using Consumers.User;
using Microsoft.Extensions.DependencyInjection;

namespace Consumers
{
    public static class Extensions
    {
        public static IServiceCollection AddConsumers(this IServiceCollection services)
        {
            services.AddHostedService<CreateUserEventConsumer>();
            return services;
        }
    }
}


//Teste-Maria

//Teste-Maria-Alice
