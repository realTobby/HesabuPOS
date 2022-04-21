using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HesabuPOS.Webinterface.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; } = string.Empty;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Message += $"{ DateTime.Now }";
        }

    }
}