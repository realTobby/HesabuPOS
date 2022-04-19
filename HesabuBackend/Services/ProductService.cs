﻿using HesabuBackend.Models;
using HesabuBackend.Models.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace HesabuBackend.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<ProductData> _productCollection;

        public ProductService(
            IOptions<HesabuDatabaseSettings> hesabuPOSDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                hesabuPOSDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                hesabuPOSDatabaseSettings.Value.DatabaseName);

            _productCollection = mongoDatabase.GetCollection<ProductData>(
                hesabuPOSDatabaseSettings.Value.ProductCollectionName);
        }

        public async Task<List<ProductData>> GetAsync() =>
            await _productCollection.Find(_ => true).ToListAsync();

        public async Task<ProductData?> GetAsync(int id) =>
            await _productCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ProductData productData) =>
            await _productCollection.InsertOneAsync(productData);

        public async Task UpdateAsync(int id, ProductData productData) =>
            await _productCollection.ReplaceOneAsync(x => x.ProductID == id, productData);

        public async Task RemoveAsync(int id) =>
            await _productCollection.DeleteOneAsync(x => x.ProductID == id);



    }
}
