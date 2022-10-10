namespace Infrastructure.Data.MongoDb.Settings;

public class MongoDbSettings : IMongoDbSettings
{
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
    public string UserCollection { get; set; }
}