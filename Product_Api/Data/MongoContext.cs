using MongoDB.Driver;
using Product_Api.Data.Model;
using Microsoft.Extensions.Options;

namespace Product_Api.Data;

public interface IMongoContext
{
    IMongoDatabase Database { get; }
}
public class MongoContext: IMongoContext
{
    public MongoContext(IProductDatabaseSettings databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.ConnectionString);
        Database = mongoClient.GetDatabase(databaseSettings.DatabaseName);
    }

    public IMongoDatabase Database { get; }

    
}