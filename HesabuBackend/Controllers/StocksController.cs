using Microsoft.AspNetCore.Mvc;
using HesabuBackend.Services;
using HesabuPOS.MasterData.Models.Data;

namespace HesabuBackend.Controllers
{
    [ApiController]
    [Route("Stocks")]
    public class StocksController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public StocksController(InventoryService serviceContext)
        {
            _inventoryService = serviceContext;
        }

        [HttpGet]
        public async Task<List<StockData>> GetInventory()
        {
            var result = await _inventoryService.GetAsync();
            return result;
        }
        
    }
}