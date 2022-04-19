using HesabuBackend.Models;
using HesabuBackend.Models.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace HesabuBackend.Services
{
    public class InventoryService
    {
        private readonly IMongoCollection<InventoryData> _inventoryCollection;

        public InventoryService(
            IOptions<HesabuDatabaseSettings> hesabuPOSDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                hesabuPOSDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                hesabuPOSDatabaseSettings.Value.DatabaseName);

            _inventoryCollection = mongoDatabase.GetCollection<InventoryData>(
                hesabuPOSDatabaseSettings.Value.InventoryCollectionName);
        }

        public async Task<List<InventoryData>> GetAsync() =>
            await _inventoryCollection.Find(_ => true).ToListAsync();

        public async Task<InventoryData?> GetAsync(int id) =>
            await _inventoryCollection.Find(x => x.InventoryID == id).FirstOrDefaultAsync();

        public async Task CreateAsync(InventoryData inventoryData) =>
            await _inventoryCollection.InsertOneAsync(inventoryData);

        public async Task UpdateAsync(int id, InventoryData inventoryData) =>
            await _inventoryCollection.ReplaceOneAsync(x => x.InventoryID == id, inventoryData);

        public async Task RemoveAsync(int id) =>
            await _inventoryCollection.DeleteOneAsync(x => x.InventoryID == id);



    }
}
