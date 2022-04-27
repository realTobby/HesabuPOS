using HesabuPOS.MasterData.Models.Data.BaseData;
using HesabuPOS.Webinterface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabuPOS.Webinterface.Pages
{
    public class ArticlesPageModel : PageModel
    {
        private readonly ArticleService _articleService;
        private readonly VariantService _variantService;

        public List<UnifiedArticle> UnifiedArticles;

        private readonly ILogger<IndexModel> _logger;


        public ArticlesPageModel(ILogger<IndexModel> logger, ArticleService articleService, VariantService variantService)
        {
            _articleService = articleService;
            _variantService = variantService;

            _logger = logger;

            UnifiedArticles = new List<UnifiedArticle>();

            var articleData = LoadArticles().Result;

            foreach(var article in articleData)
            {
                UnifiedArticle unified = new UnifiedArticle();
                unified.ArticleData = article;
                unified.Variants = LoadVariants(article.ArticleNumber).Result;
                UnifiedArticles.Add(unified);
            }
        }


        private async Task<List<ArticleData>> LoadArticles()
        {
            return await _articleService.GetAsync();
        }

        private async Task<List<ArticleVariantData>> LoadVariants(string number)
        {
            return await _variantService.GetVariantsByArticleNumber(number);
        }

        public async Task<IActionResult> OnPostDelete(string id)
        {
            await _articleService.RemoveAsync(id);

            return RedirectToPage("/ArticlesPage");
        }

    }
}
