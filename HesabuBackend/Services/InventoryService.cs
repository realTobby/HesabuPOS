using HesabuBackend.Models;
using HesabuPOS.MasterData.Models.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace HesabuBackend.Services
{
    public class InventoryService
    {
        private readonly IMongoCollection<StockData> _inventoryCollection;

        public InventoryService(
            IOptions<HesabuDatabaseSettings> hesabuPOSDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                hesabuPOSDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                hesabuPOSDatabaseSettings.Value.DatabaseName);

            _inventoryCollection = mongoDatabase.GetCollection<StockData>(
                hesabuPOSDatabaseSettings.Value.StocksCollectionName);
        }

        public async Task<List<StockData>> GetAsync() =>
            await _inventoryCollection.Find(_ => true).ToListAsync();

        public async Task<StockData?> GetAsync(int id) =>
            await _inventoryCollection.Find(x => x.StockID == id).FirstOrDefaultAsync();

        public async Task CreateAsync(StockData inventoryData) =>
            await _inventoryCollection.InsertOneAsync(inventoryData);

        public async Task UpdateAsync(int id, StockData inventoryData) =>
            await _inventoryCollection.ReplaceOneAsync(x => x.StockID == id, inventoryData);

        public async Task RemoveAsync(int id) =>
            await _inventoryCollection.DeleteOneAsync(x => x.StockID == id);



    }
}
