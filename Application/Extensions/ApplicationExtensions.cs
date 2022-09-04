using Application.UseCases.User.CreateUser;
using Application.UseCases.User.RequestCreateUser;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static void RegisterApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRequestCreateUserUseCase, RequestCreateUserUseCase>();
            services.AddTransient<ICreateUserUseCase, CreateUserUseCase>();
        }
    }
}
