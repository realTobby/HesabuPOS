using HesabuPOS.Webinterface.Models;
using HesabuPOS.MasterData.Models.Data.BaseData;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace HesabuPOS.Webinterface.Services
{
    public class VariantService
    {
        private readonly IMongoCollection<ArticleVariantData> _variantsCollection;

        public VariantService(
            IOptions<HesabuDatabaseSettings> hesabuPOSDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                hesabuPOSDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                hesabuPOSDatabaseSettings.Value.DatabaseName);

            _variantsCollection = mongoDatabase.GetCollection<ArticleVariantData>(
                hesabuPOSDatabaseSettings.Value.ArticleVariantsCollectionName);
        }

        public async Task<List<ArticleVariantData>> GetAsync()
        {
            return await _variantsCollection.Find(_ => true).ToListAsync();
        }
            
        public async Task<ArticleVariantData?> GetAsync(string variantNumber) =>
            await _variantsCollection.Find(x => x.ArticleVariantNumber == variantNumber).FirstOrDefaultAsync();

        public async Task<ArticleVariantData> PostProduct(string articleNumber, string variantNumber, double price, string color, string size)
        {
            ArticleVariantData newProduct = new ArticleVariantData { ArticleNumber = articleNumber, ArticleVariantNumber = variantNumber, ArticleVariantPrice = price, ArticleVariantColor = color, ArticleVariantSize = size };
            await _variantsCollection.InsertOneAsync(newProduct);
            return newProduct;
        }

        public async Task<List<ArticleVariantData>> GetVariantsByArticleNumber(string articleNumber)
        {
            return await _variantsCollection.Find(x=>x.ArticleNumber == articleNumber).ToListAsync();
        }

        public async Task CreateAsync(ArticleVariantData productData) =>
            await _variantsCollection.InsertOneAsync(productData);

        public async Task UpdateAsync(string articleNumber, ArticleVariantData productData) =>
            await _variantsCollection.ReplaceOneAsync(x => x.ArticleNumber == articleNumber, productData);

        public async Task RemoveAsync(string articleNumber) =>
            await _variantsCollection.DeleteOneAsync(x => x.ArticleNumber == articleNumber);



    }
}
