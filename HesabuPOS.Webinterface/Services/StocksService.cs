using HesabuPOS.Webinterface.Models;
using HesabuPOS.MasterData.Models.Data.RuntimeData;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace HesabuPOS.Webinterface.Services
{
    public class StocksService
    {
        private readonly IMongoCollection<StockData> _stockCollection;

        public StocksService(
            IOptions<HesabuDatabaseSettings> hesabuPOSDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                hesabuPOSDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                hesabuPOSDatabaseSettings.Value.DatabaseName);

            _stockCollection = mongoDatabase.GetCollection<StockData>(
                hesabuPOSDatabaseSettings.Value.StocksCollectionName);
        }

        public async Task<List<StockData>> GetAsync() =>
            await _stockCollection.Find(_ => true).ToListAsync();

        public async Task<StockData?> GetAsync(int id) =>
            await _stockCollection.Find(x => x.StockID == id).FirstOrDefaultAsync();

        public async Task CreateAsync(StockData inventoryData) =>
            await _stockCollection.InsertOneAsync(inventoryData);

        public async Task UpdateAsync(int id, StockData inventoryData) =>
            await _stockCollection.ReplaceOneAsync(x => x.StockID == id, inventoryData);

        public async Task RemoveAsync(int id) =>
            await _stockCollection.DeleteOneAsync(x => x.StockID == id);



    }
}
