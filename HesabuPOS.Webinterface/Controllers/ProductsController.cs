using Microsoft.AspNetCore.Mvc;
using HesabuPOS.Webinterface.Services;
using HesabuPOS.MasterData.Models.Data.BaseData;

namespace HesabuPOS.Webinterface.Controllers
{
    [ApiController]
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
        public ProductData PostProdcut([FromQuery(Name = "productName")] string productName,
                                    [FromQuery(Name = "productDescription")] string description,
                                    [FromQuery(Name = "productPrice")] double price,
                                    [FromQuery(Name = "prodcutImage")] string imageUrl)
        {
            return _productService.PostProduct(productName, description, price, imageUrl).Result;
        }
    }
}