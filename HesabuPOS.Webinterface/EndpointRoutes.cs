namespace HesabuPOS.Webinterface
{
    public static class EndpointRoutes
    {
        #region Products

        public const string ProductsRoute = "products";

        public const string GetProducts = ProductsRoute + "/list";

        public const string GetProductByID = ProductsRoute + "/{id}";

        public const string PostProduct = ProductsRoute + "/post";
        #endregion

        #region Storages

        public const string StoragesRoute = "storages";

        public const string GetStorages = StoragesRoute + "/list";

        public const string GetStorageByID = StoragesRoute + "/{id}";

        #endregion

        #region Stocks

        public const string StocksRoute = "stocks";

        public const string GetStocks = StocksRoute + "/list";

        public const string GetStocksByStorageID = StocksRoute + "/{id}";


        #endregion

    }
}
