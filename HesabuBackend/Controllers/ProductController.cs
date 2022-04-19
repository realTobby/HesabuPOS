using Microsoft.AspNetCore.Mvc;
using HesabuBackend.Services;
using HesabuBackend.Models.Data;

namespace HesabuBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService serviceContext)
        {
            _productService = serviceContext;
        }

        [HttpGet]
        public async Task<List<ProductData>> GetProducts()
        {
            var result = await _productService.GetAsync();
            return result;
        }
        
    }
}