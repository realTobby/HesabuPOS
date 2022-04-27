using HesabuPOS.MasterData.Models.Data.BaseData;
using HesabuPOS.Webinterface.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.JSInterop;

namespace HesabuPOS.Webinterface.Pages
{

    public class IncomingGoodsModel : PageModel
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [BindProperty]
        public int SelectedArticleTag { get; set; }

        private StorageService _storageService;
        private ArticleService _articleService;
        private VariantService _variantService;

        public List<SelectListItem> StoragesDropdownItems { get; set; }

        public List<SelectListItem> ArticlesDropdownItems { get; set; }

        public List<SelectListItem> ArticleVariantsDropdownItems { get; set; }

        public List<StorageData> Storages;

        public List<UnifiedArticle> UnifiedArticles;

        public IncomingGoodsModel(StorageService storageService, ArticleService articleService, VariantService variantService)
        {
            _storageService = storageService;
            _articleService = articleService;
            _variantService = variantService;

            Storages = new List<StorageData>();
            Storages = _storageService.GetAsync().Result;

            StoragesDropdownItems = Storages.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.StorageID.ToString(),
                                              Text = $"{a.StorageName} - {a.StorageLocation}"
                                          }).ToList();

            var articleData = LoadArticles().Result;

            ArticlesDropdownItems = articleData.Select(a =>
                                            new SelectListItem
                                            {
                                                Value = a.ArticleNumber,
                                                Text = $"{a.ArticleNumber} - {a.Name}"
                                            }).ToList();


            UnifiedArticles = new List<UnifiedArticle>();

            foreach (var article in articleData)
            {
                UnifiedArticle unified = new UnifiedArticle();
                unified.ArticleData = article;
                unified.Variants = LoadVariants(article.ArticleNumber).Result;
                UnifiedArticles.Add(unified);
            }

           

        }

        public void UpdateVariants(ChangeEventArgs e)
        {
            string articleNumber = ArticlesDropdownItems[SelectedArticleTag].Value;

            var unifiedVariants = LoadVariants(articleNumber).Result.ToList();

            ArticleVariantsDropdownItems = unifiedVariants.Select(v => new SelectListItem
            {
                Value = v.ArticleVariantNumber,
                Text = $"{v.ArticleVariantNumber} - {v.ArticleVariantSize} - {v.ArticleVariantPrice}"
            }).ToList();
        }




        private async Task SendDotNetInstanceToJS()
        {
            var dotNetObjRef = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("jsFunctions.showMouseCoordinates", dotNetObjRef);
        }


        private async Task<List<ArticleData>> LoadArticles()
        {
            return await _articleService.GetAsync();
        }

        private async Task<List<ArticleVariantData>> LoadVariants(string number)
        {
            return await _variantService.GetVariantsByArticleNumber(number);
        }

        public void OnGet()
        {
        }
    }
}
