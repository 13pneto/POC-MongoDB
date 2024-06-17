using MongoDB.Driver;

namespace POC.MongoDB2.Data.Repositories.Interfaces;

public interface IBaseRepository<T>
{
    Task<List<T>> GetAll();
    Task<T> Add(T game);
    Task Remove(string id);
    Task<T> Update(T game);
}