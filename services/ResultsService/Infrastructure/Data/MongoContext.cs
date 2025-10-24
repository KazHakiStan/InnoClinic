using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ResultsService.Domain.Entities;

namespace ResultsService.Infrastructure.Data;

public class MongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext(IOptions<MongoSettings> settings)
    {
        var config = MongoClientSettings.FromConnectionString(settings.Value.ConnectionString);
        config.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(config);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<Result> Results => _database.GetCollection<Result>("Results");
}

public class MongoSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}
