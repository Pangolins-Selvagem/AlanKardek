using AlanKardek.Migrations;
using AlanKardek.Models.Father;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlanKardek.Pages.Aluno_View
{
    public class ContatoModel : PageModel
    {
        private readonly AlanKardekContext _context;

        public ContatoModel (AlanKardekContext context)
        {
            _context = context;
        }

        public Usuario Admin { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            var id = HttpContext.Session.GetInt32("USUARIO_ID");

            var admin = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);

            if (admin == null)
            {
                return NotFound();
            }
            else if (admin.Tipo != "U")
            {
                return NotFound();
            }

            Admin = admin;

            return Page();
        }
    }
}
