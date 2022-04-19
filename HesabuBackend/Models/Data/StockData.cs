using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HesabuBackend.Models.Data
{
    public class StockData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        [BsonElement("StockID")]
        public int StockID { get; set; }
        [BsonElement("ProductID")]
        public int ProductID { get; set; }
        [BsonElement("ProductQuantity")]
        public int ProductQuantity { get; set; }

        //public Product Product { get; set; }
    }
}
