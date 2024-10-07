using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OWSInstanceLauncher.Pages.Home
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "test 1";
        }
    }
}