using MongoDB.Driver;


namespace POC.MongoDB2.Data.Repositories;

public class ColorsRepository : IColorsRepository
{
    private readonly IMongoCollection<Entities.Color> _colors;
    
    public ColorsRepository(IMongoDatabase database)
    {
        _colors = database.GetCollection<Entities.Color>("Colors");
    }

    public Task<List<Entities.Color>> GetAll()
    {
        return _colors
            .Find(_ => true)
            .ToListAsync();
    }

    public Task<Entities.Color> Add(Entities.Color game)
    {
        _colors.InsertOne(game);
        return Task.FromResult(game);
    }
}