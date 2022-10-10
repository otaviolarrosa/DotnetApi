using Application.Infrastructure.Data.MongoDb.Repositories;
using Domain.Entities;
using Infrastructure.Data.MongoDb.Repositories;
using Infrastructure.Data.MongoDb.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Data.MongoDb.Extensions;

public static class MongoDbExtensions
{
    public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

        services.AddSingleton<IMongoDbSettings>(serviceProvider =>
            serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        
        services.AddTransient(typeof(IMongoRepository<>), typeof(MongoRepository<>));
        
        CreateIndex(configuration);
    }

    private static void CreateIndex(IConfiguration configuration)
    {
        var connString = configuration.GetSection("MongoDbSettings:ConnectionString").Value;
        var dbString = configuration.GetSection("MongoDbSettings:DatabaseName").Value;
        var dbCollection = configuration.GetSection("MongoDbSettings:UserCollection").Value;
        
        var mongoClient = new MongoClient(connString);
        var db = mongoClient.GetDatabase(dbString);
        var users = db.GetCollection<User>(dbCollection);
        
        var indexModel = new CreateIndexModel<User>(
            new IndexKeysDefinitionBuilder<User>()
                .Ascending(x => x.FirstName)
                .Ascending(x => x.LastName),
            new CreateIndexOptions()
            {
                Unique = true
            });

        users.Indexes.CreateOne(indexModel);
    }
}