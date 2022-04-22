namespace HesabuPOS.Webinterface
{
    public static class EndpointRoutes
    {
        #region Articles

        public const string ArticlesRoute = "articles";

        public const string GetArticleByID = ArticlesRoute + "/{articleNumber}";

        public const string PostArticle = ArticlesRoute + "/post";

        public const string PostArticleViaImport = ArticlesRoute + "/import";

        public const string DeleteArticleByID = ArticlesRoute + "/delete/{articleNumber}";

        #endregion

        #region Storages

        public const string StoragesRoute = "storages";

        public const string GetStorageByID = StoragesRoute + "/{storageID}";

        #endregion

        #region Stocks

        public const string StocksRoute = "stocks";

        public const string GetStocksByStorageID = StocksRoute + "/{storageID}";


        #endregion


        #region Article Variants

        public const string ArticleVariantsRoute = "articlevariants";

        public const string GetArticleVariantByID = ArticleVariantsRoute + "/{variantNumber}";

        public const string PostArticleVariant = ArticleVariantsRoute + "/post";

        #endregion
    }
}
