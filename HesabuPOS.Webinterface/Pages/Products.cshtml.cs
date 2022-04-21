using HesabuPOS.MasterData.Models.Data;
using HesabuPOS.Webinterface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabuPOS.Webinterface.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ProductService _someSharedPageService;

        public List<ProductData> Products;

        private readonly ILogger<IndexModel> _logger;


        public ProductsModel(ILogger<IndexModel> logger, ProductService _pService)
        {
            _someSharedPageService = _pService;

            _logger = logger;

            Products = new List<ProductData>();
            Products = LoadData().Result;
        }


        private async Task<List<ProductData>> LoadData()
        {
            return await _someSharedPageService.GetAsync();
        }

        public void OnClick(object sender)
        {
            Console.WriteLine("Test click!");
        }
    }
}
