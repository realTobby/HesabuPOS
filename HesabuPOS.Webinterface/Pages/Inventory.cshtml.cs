using HesabuPOS.MasterData.Models.Data.BaseData;
using HesabuPOS.Webinterface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabuPOS.Webinterface.Pages
{
    public class InventoryModel : PageModel
    {
        private readonly StorageService _storageService;

        public List<StorageData> Storages;

        private readonly ILogger<IndexModel> _logger;


        public InventoryModel(ILogger<IndexModel> logger, StorageService storageService)
        {
            _storageService = storageService;

            _logger = logger;

            Storages = new List<StorageData>();
            Storages = LoadData().Result;
        }


        private async Task<List<StorageData>> LoadData()
        {
            return await _storageService.GetAsync();
        }
    }
}
