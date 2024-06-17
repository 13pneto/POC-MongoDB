using MongoDB.Driver;
using POC.MongoDB2.Data.Repositories.Interfaces;
using POC.MongoDB2.Entities;

namespace POC.MongoDB2.Data.Repositories;

public class GameRepository : BaseRepository<Game>, IGamesRepository
{
    public GameRepository(IMongoDatabase database) : base(database, "Games")
    {
    }
}