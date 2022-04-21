using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabuPOS.Webinterface.Pages
{
    public class IndexModel : PageModel
    {
        public string CurrentServerTime { get; set; } = string.Empty;

        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            CurrentServerTime = $"{ DateTime.Now }";
        }
    }
}