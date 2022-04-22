using Microsoft.AspNetCore.Mvc;
using HesabuPOS.Webinterface.Services;
using HesabuPOS.MasterData.Models.Data.BaseData;

namespace HesabuPOS.Webinterface.Controllers
{
    [ApiController]
    public class ArticleVariantsController : ControllerBase
    {
        private readonly VariantService _variantService;

        public ArticleVariantsController(VariantService serviceContext)
        {
            _variantService = serviceContext;
        }

        [HttpGet(EndpointRoutes.ArticleVariantsRoute)]
        public async Task<List<ArticleVariantData>> GetProducts()
        {
            var result = await _variantService.GetAsync();
            return result;
        }

        [HttpGet(EndpointRoutes.GetArticleVariantByID)]
        public async Task<ArticleVariantData> GetProduct(string variantNumber)
        {
            var result = await _variantService.GetAsync(variantNumber);
            if (result == null)
            {
                throw new Exception($"No Product found with ID: {variantNumber}");
            }
            return await _variantService.GetAsync(variantNumber);
        }

        [HttpPost(EndpointRoutes.PostArticleVariant)]
        public async Task<ArticleVariantData> PostVariant(string articleNumber, string variantNumber, double price, string color, string size)
        {
            return await _variantService.PostProduct(articleNumber, variantNumber, price, color, size);
        }


    }
}