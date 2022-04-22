namespace HesabuPOS.Webinterface.Models
{
    public class HesabuDatabaseSettings
    { 
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string StocksCollectionName { get; set; } = null!;
        public string ArticlesCollectionName { get; set; } = null!;

        public string StoragesCollectionName { get; set; } = null!;

        public string ArticleVariantsCollectionName { get; set; } = null!;
    }
}
