using MongoDB.Bson.Serialization.Attributes;

namespace MyCQRSProject.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonElement]
        public string? Name { get; set; }
        [BsonElement]
        public decimal Price { get; set; }
        [BsonElement]
        public int Stock { get; set; }
        [BsonElement]
        public DateTime CreatedAt { get; set; }
    }
}
