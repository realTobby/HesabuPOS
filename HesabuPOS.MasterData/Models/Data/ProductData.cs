using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HesabuPOS.MasterData.Models.Data
{
    public class ProductData
    {
        [BsonElement("_id")]
        public ObjectId ObjectID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
    }
}
