using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product_Api.Data.Model;
public class Category
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }    
   


}