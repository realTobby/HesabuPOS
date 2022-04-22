

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HesabuPOS.MasterData.Models.Data.RuntimeData
{
    public class StockData
    {
        [BsonElement("_id")]
        public ObjectId ObjectID { get; set; }
        public int StockID { get; set; }
        public int StorageID { get; set; }
        public string ArticleVariantNumber { get; set; }
        public string ElementString { get; set; }
        public int ProductQuantity { get; set; }
    }
}
