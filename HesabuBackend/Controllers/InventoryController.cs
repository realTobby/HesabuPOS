using Microsoft.AspNetCore.Mvc;
using HesabuBackend.Services;
using HesabuBackend.Models.Data;

namespace HesabuBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public InventoryController(InventoryService serviceContext)
        {
            _inventoryService = serviceContext;
        }

        [HttpGet]
        public async Task<List<InventoryData>> GetInventory()
        {
            var result = await _inventoryService.GetAsync();
            return result;
        }
        
    }
}