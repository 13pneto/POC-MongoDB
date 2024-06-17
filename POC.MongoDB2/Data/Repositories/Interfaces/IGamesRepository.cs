using POC.MongoDB2.Entities;

namespace POC.MongoDB2.Data.Repositories;

public interface IGamesRepository
{
    Task<List<Game>> GetAll();
    Task<Game> Add(Game game);
}