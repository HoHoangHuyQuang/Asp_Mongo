using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product_Api.Data.Model;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public Decimal Price { get; set; }
    public string? Description { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("categoryId")]
    public List<string>? CategoryId { get; set; }

}
