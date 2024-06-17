using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace POC.MongoDB2.Entities;

public class Color : BaseEntity
{
    public string Name { get; set; }
}