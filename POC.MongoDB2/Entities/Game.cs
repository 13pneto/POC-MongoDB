namespace POC.MongoDB2.Entities;

public class Game : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Gender { get; set; }
    public int Year { get; set; }
}