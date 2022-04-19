using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HesabuBackend.Models.Data
{
    public class ProductData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        [BsonElement("ID")]
        public int ProductID { get; set; }

        [BsonElement("ProductName")]
        public string ProductName { get; set; }

        [BsonElement("ProductDescription")]
        public string ProductDescription { get; set; }

        [BsonElement("ProductPrice")]
        public double ProductPrice { get; set; }

    }
}
