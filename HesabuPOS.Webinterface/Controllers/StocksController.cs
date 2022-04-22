using Microsoft.AspNetCore.Mvc;
using HesabuPOS.Webinterface.Services;
using HesabuPOS.MasterData.Models.Data.RuntimeData;

namespace HesabuPOS.Webinterface.Controllers
{
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly StocksService _stockService;

        public StocksController(StocksService serviceContext)
        {
            _stockService = serviceContext;
        }

        [HttpGet(EndpointRoutes.StocksRoute)]
        public async Task<List<StockData>> GetStocks()
        {
            var result = await _stockService.GetAsync();
            return result;
        }
        
    }
}