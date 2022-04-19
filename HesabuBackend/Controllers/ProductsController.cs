using Microsoft.AspNetCore.Mvc;
using HesabuBackend.Services;
using HesabuPOS.MasterData.Models.Data;

namespace HesabuBackend.Controllers
{
    [ApiController]
    //[Route(EndpointRoutes.ProductsRoute)] ==> MAYBE NOT NEEDED!!!
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService serviceContext)
        {
            _productService = serviceContext;
        }

        [HttpGet(EndpointRoutes.GetProducts)]
        public async Task<List<ProductData>> GetProducts()
        {
            var result = await _productService.GetAsync();
            return result;
        }

        [HttpGet(EndpointRoutes.GetProductByID)]
        public async Task<ProductData> GetProduct(int id)
        {
            var result = await _productService.GetAsync(id);
            if (result == null)
            {
                throw new Exception($"No Product found with ID: {id}");
            }
            return await _productService.GetAsync(id);
        }

        [HttpPost(EndpointRoutes.PostProduct)]
        public ProductData PostProdcut([FromQuery(Name = "prodcut")] string productName,
                                    [FromQuery(Name = "description")] string description,
                                    [FromQuery(Name = "price")] double price)
        {
            return _productService.PostProduct(productName, description, price).Result;
        }
    }
}