using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DataAccess.Models;

public record Car
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement]
    public string Model { get; set; } = string.Empty;

    [BsonElement]
    public string Make { get; set; } = string.Empty;

    [BsonElement]
    public string Color { get; set; } = string.Empty;

    [BsonElement]
    public int HorsePower { get; set; }
}

