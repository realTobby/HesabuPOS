using Microsoft.AspNetCore.Mvc;
using HesabuPOS.Webinterface.Services;
using HesabuPOS.MasterData.Models.Data.BaseData;

namespace HesabuPOS.Webinterface.Controllers
{
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly StorageService _storageService;

        public StorageController(StorageService serviceContext)
        {
            _storageService = serviceContext;
        }

        [HttpGet(EndpointRoutes.StoragesRoute)]
        public async Task<List<StorageData>> GetStorages()
        {
            var result = await _storageService.GetAsync();
            return result;
        }
        
    }
}