using Product_Api.Data;
using MongoDB.Driver;

namespace Product_Api.Repository.Implement;

public abstract class BaseRepo<T, ID> : IBaseRepo<T, ID> where T : class
{
    protected readonly IMongoDatabase Database;
    protected readonly IMongoCollection<T> MongoCollection;

    public BaseRepo(IMongoContext context)
    {
        Database = context.Database;
        MongoCollection = Database.GetCollection<T>(typeof(T).Name);
    }
    public virtual async Task Delete(ID entityId)
    {
        var filter = Builders<T>.Filter.Eq("Id", entityId);
        await MongoCollection.DeleteOneAsync(filter);
        return;
    }

    public virtual async Task<List<T>> FindAll()
    {
        var all = await MongoCollection.Find(e => true).ToListAsync();
        return all;
    }

    public virtual async Task<T> FindById(ID entityId)
    {
        var filter = Builders<T>.Filter.Eq("Id", entityId);
        return await MongoCollection.Find(filter).FirstOrDefaultAsync();
    }

    public virtual async Task Save(T entity)
    {
        await MongoCollection.InsertOneAsync(entity);
        return ;
    }

    public virtual async Task Update(ID entityId, T entity)
    {
        var filter = Builders<T>.Filter.Eq("Id", entityId);
        await MongoCollection.ReplaceOneAsync(filter, entity);
        return ;
    }


    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}