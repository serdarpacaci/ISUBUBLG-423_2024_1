using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IsubuSatis.KatalogApi.Models
{
    public class Kategori
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonRepresentation(BsonType.String)]
        public string Ad { get; set; }
    }
}
