using MongoDB.Driver;
using POC.MongoDB2.Data.Repositories.Interfaces;
using POC.MongoDB2.Entities;


namespace POC.MongoDB2.Data.Repositories;

public class ColorsRepository : BaseRepository<Color>, IColorsRepository
{
    public ColorsRepository(IMongoDatabase database) : base(database, "Colors")
    {
    }
}