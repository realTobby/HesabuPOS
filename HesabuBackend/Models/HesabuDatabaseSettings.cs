namespace HesabuBackend.Models
{
    public class HesabuDatabaseSettings
    { 
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string InventoryCollectionName { get; set; } = null!;
        public string ProductCollectionName { get; set; } = null!;
    }
}
