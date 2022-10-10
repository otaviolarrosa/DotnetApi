using Application.Infrastructure.Data.Postgres.Repositories;
using Domain.Entities;
using Infrastructure.Data.MongoDb.Extensions;
using Infrastructure.Data.Postgres.Context;
using Infrastructure.Data.Postgres.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static void RegisterInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var usePostgres = Convert.ToBoolean(configuration.GetSection("DatabaseUsage:UsePostgres").Value);
            var useMongoDb = Convert.ToBoolean(configuration.GetSection("DatabaseUsage:UseMongoDb").Value);

            if (usePostgres)
            {
                services.AddTransient<DataContext>();

                services.AddDbContext<DataContext>(options => options
                    .EnableSensitiveDataLogging()
                    .UseNpgsql(configuration.GetConnectionString("Database")), ServiceLifetime.Transient);
                services.AddTransient<IRepository<User>, Repository<User>>();
            }

            if (useMongoDb)
            {
                services.AddMongoDb(configuration);
            }
        }

        public static void RunMigrations(this WebApplication app, IConfiguration configuration)
        {
            var usePostgres = Convert.ToBoolean(configuration.GetSection("DatabaseUsage:UsePostgres").Value);
            if (usePostgres)
            {
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                }
            }
        }
    }
}