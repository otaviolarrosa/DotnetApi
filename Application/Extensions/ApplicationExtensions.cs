using Application.UseCases.CreateTopic;
using Application.UseCases.DeleteTopic;
using Application.UseCases.GetTopicData;
using Application.UseCases.GetTopicsData;
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
            services.AddTransient<ICreateTopicUseCase, CreateTopicUseCase>();
            services.AddTransient<IGetTopicDataUseCase, GetTopicDataUseCase>();
            services.AddTransient<IGetTopicsDataUseCase, GetTopicsDataUseCase>();
            services.AddTransient<IDeleteTopicUseCase, DeleteTopicUseCase>();
        }
    }
}
