namespace HesabuPOS.Webinterface
{
    public static class EndpointRoutes
    {
        public const string ProductsRoute = "products";

        public const string GetProducts = ProductsRoute + "/list";

        public const string GetProductByID = ProductsRoute + "/{id}";

        public const string PostProduct = ProductsRoute + "/post";

    }
}
