using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlanKardek.Pages
{
    public class Senha_EModel : PageModel
    {
        public string? Mensagem = null;

        public IActionResult OnGet()
        {
            var mensagem = HttpContext.Session.GetString("MENSAGEMS");
            if (mensagem == null)
            {

                return Page();
            }
            Mensagem = mensagem;
            return Page();
        }

        public void OnPost()
        {
            HttpContext.Session.Clear();
        }
    }
}
