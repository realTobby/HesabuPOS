using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesabuPOS.MasterData.Models.Data.BaseData
{
    public class StorageData
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId ObjectID { get; set; }
        public int StorageID { get; set; }
        public string StorageName { get; set; }
        public string StorageLocation { get; set; }
        public string StorageContactPerson { get; set; }

    }
}
