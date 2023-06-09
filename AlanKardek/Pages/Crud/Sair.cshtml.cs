using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AlanKardek.Pages.Crud
{
    public class SairModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            return Redirect("https://localhost:7132");
        }
    }
}
