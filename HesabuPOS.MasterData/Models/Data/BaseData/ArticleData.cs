using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HesabuPOS.MasterData.Models.Data.BaseData
{
    public class ArticleData
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId ObjectID { get; set; }
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
    }
}
