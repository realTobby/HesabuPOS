

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HesabuPOS.MasterData.Models.Data
{
    public class StockData
    {
        [BsonElement("_id")]
        public ObjectId ObjectID { get; set; }
        public int StockID { get; set; }
        public int ProductID { get; set; }
        public int ProductQuantity { get; set; }
    }
}
