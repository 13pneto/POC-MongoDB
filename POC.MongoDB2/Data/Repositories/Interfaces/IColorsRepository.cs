using System.Drawing;

namespace POC.MongoDB2.Data.Repositories;

public interface IColorsRepository
{
    Task<List<Entities.Color>> GetAll();
    Task<Entities.Color> Add(Entities.Color game);
}