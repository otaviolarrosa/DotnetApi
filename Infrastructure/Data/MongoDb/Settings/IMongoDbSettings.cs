namespace Infrastructure.Data.MongoDb.Settings;

public interface IMongoDbSettings
{
    string DatabaseName { get; set; }
    string ConnectionString { get; set; }
    string UserCollection { get; set; }
}