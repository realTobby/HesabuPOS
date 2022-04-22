using HesabuPOS.Webinterface.Models;
using HesabuPOS.MasterData.Models.Data.BaseData;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace HesabuPOS.Webinterface.Services
{
    public class ArticleService
    {
        private readonly IMongoCollection<ArticleData> _productCollection;

        public ArticleService(
            IOptions<HesabuDatabaseSettings> hesabuPOSDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                hesabuPOSDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                hesabuPOSDatabaseSettings.Value.DatabaseName);

            _productCollection = mongoDatabase.GetCollection<ArticleData>(
                hesabuPOSDatabaseSettings.Value.ArticlesCollectionName);
        }

        public async Task<List<ArticleData>> GetAsync() =>
            await _productCollection.Find(_ => true).ToListAsync();

        public async Task<ArticleData?> GetAsync(string articleNumber) =>
            await _productCollection.Find(x => x.ArticleNumber == articleNumber).FirstOrDefaultAsync();

        public async Task<ArticleData> PostProduct(string articleNumber, string name, string description, double price, string imageUrl)
        {
            ArticleData newProduct = new ArticleData { ArticleNumber = articleNumber, Name = name, Description = description, Price = price, ImageURL = imageUrl };
            await _productCollection.InsertOneAsync(newProduct);
            return newProduct;
        }

        public async Task CreateAsync(ArticleData productData) =>
            await _productCollection.InsertOneAsync(productData);

        public async Task UpdateAsync(string articleNumber, ArticleData productData) =>
            await _productCollection.ReplaceOneAsync(x => x.ArticleNumber == articleNumber, productData);

        public async Task RemoveAsync(string articleNumber) =>
            await _productCollection.DeleteOneAsync(x => x.ArticleNumber == articleNumber);




    }
}
