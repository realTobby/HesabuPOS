using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesabuPOS.MasterData.Models.Data.BaseData
{
    public class ArticleVariantData
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId ObjectID { get; set; }
        public string ArticleVariantNumber { get; set; }
        public string ArticleNumber { get; set; }
        public double ArticleVariantPrice { get; set; }
        public string ArticleVariantColor { get; set; }
        public string ArticleVariantSize { get; set; }
    }
}
