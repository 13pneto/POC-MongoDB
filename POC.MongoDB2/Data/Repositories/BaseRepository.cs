using MongoDB.Driver;
using POC.MongoDB2.Entities;

namespace POC.MongoDB2.Data.Repositories;

public class BaseRepository<T> where T : BaseEntity
{
    protected readonly IMongoCollection<T> _collection;
    

    protected BaseRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<T>(collectionName);
    }
    
    public async Task<List<T>> GetAll()
    {
        return await _collection
            .Find(_ => true)
            .ToListAsync();
    }

    public async Task<T> Add(T entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public Task Remove(string id)
    {
        return _collection
            .DeleteOneAsync(x => x.Id == id);
    }

    public async Task<T> Update(T entity)
    {
        await _collection
            .ReplaceOneAsync(x => x.Id == entity.Id, entity);
        
        return entity;
    }
}