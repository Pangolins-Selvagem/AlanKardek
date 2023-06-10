using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
<<<<<<< HEAD
=======

>>>>>>> b67530e58ae6b6379221ef5319fc269f053d29be

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
