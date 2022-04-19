using Microsoft.AspNetCore.Mvc;
using HesabuBackend.Services;
using HesabuBackend.Models.Data;

namespace HesabuBackend.Controllers
{
    [ApiController]
    [Route("stock")]
    public class StockController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public StockController(InventoryService serviceContext)
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