namespace HesabuBackend.Models
{
    public class HesabuDatabaseSettings
    { 
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string StocksCollectionName { get; set; } = null!;
        public string ProductsCollectionName { get; set; } = null!;
    }
}
