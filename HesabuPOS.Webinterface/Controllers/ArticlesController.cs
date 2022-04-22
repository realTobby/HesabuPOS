using Microsoft.AspNetCore.Mvc;
using HesabuPOS.Webinterface.Services;
using HesabuPOS.MasterData.Models.Data.BaseData;

namespace HesabuPOS.Webinterface.Controllers
{
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleService _articleService;

        public ArticlesController(ArticleService serviceContext)
        {
            _articleService = serviceContext;
        }

        [HttpGet(EndpointRoutes.ArticlesRoute)]
        public async Task<List<ArticleData>> GetArticles()
        {
            var result = await _articleService.GetAsync();
            return result;
        }

        [HttpGet(EndpointRoutes.GetArticleByID)]
        public async Task<ArticleData> GetArticle(string articleNumber)
        {
            var result = await _articleService.GetAsync(articleNumber);
            if (result == null)
            {
                throw new Exception($"No Product found with ID: {articleNumber}");
            }
            return await _articleService.GetAsync(articleNumber);
        }

        [HttpPost(EndpointRoutes.PostArticle)]
        public ArticleData PostProdcut([FromQuery(Name = "articleNumber")] string articleNumber,
                                    [FromQuery(Name = "articleName")] string articleName,
                                    [FromQuery(Name = "articleDescription")] string articleDescription,
                                    [FromQuery(Name = "articlePrice")] double articlePrices,
                                    [FromQuery(Name = "articleImageURL")] string imageURL)
        {
            return _articleService.PostProduct(articleNumber, articleName, articleDescription, articlePrices, imageURL).Result;
        }

        [HttpPost(EndpointRoutes.PostArticleViaImport)]
        public async Task<IActionResult> ImportPrdocut([FromForm(Name = "articleNumber")] string articleNumber,
                                    [FromForm(Name = "articleName")] string articleName,
                                    [FromForm(Name = "articleDescription")] string articleDescription,
                                    [FromForm(Name = "articlePrice")] double articlePrices,
                                    [FromForm(Name = "articleImageURL")] string imageURL)
        {
            await _articleService.PostProduct(articleNumber, articleName, articleDescription, articlePrices, imageURL);

            return RedirectToPage("/ArticlesPage");
        }

        [HttpDelete(EndpointRoutes.DeleteArticleByID)]
        public async Task<IActionResult> DeleteArticleByID([FromRoute(Name = "articleNumber")] string articleNumber)
        {
            await _articleService.RemoveAsync(articleNumber);

            return RedirectToPage("/ArticlesPage");
        }

    }
}