using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlanKardek.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string? Mensagem = null;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            var mensagem = HttpContext.Session.GetString("MENSAGEM");
            if(mensagem == null){

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