using HesabuPOS.Webinterface.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using HesabuPOS.MasterData.Models.Data.BaseData;

namespace HesabuPOS.Webinterface.Services
{
    public class StorageService
    {
        private readonly IMongoCollection<StorageData> _storageCollection;

        public StorageService(
            IOptions<HesabuDatabaseSettings> hesabuPOSDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                hesabuPOSDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                hesabuPOSDatabaseSettings.Value.DatabaseName);

            _storageCollection = mongoDatabase.GetCollection<StorageData>(
                hesabuPOSDatabaseSettings.Value.StoragesCollectionName);
        }

        public async Task<List<StorageData>> GetAsync() =>
            await _storageCollection.Find(_ => true).ToListAsync();

        public async Task<StorageData?> GetAsync(int id) =>
            await _storageCollection.Find(x => x.StorageID == id).FirstOrDefaultAsync();

        public async Task CreateAsync(StorageData inventoryData) =>
            await _storageCollection.InsertOneAsync(inventoryData);

        public async Task UpdateAsync(int id, StorageData inventoryData) =>
            await _storageCollection.ReplaceOneAsync(x => x.StorageID == id, inventoryData);

        public async Task RemoveAsync(int id) =>
            await _storageCollection.DeleteOneAsync(x => x.StorageID == id);



    }
}
