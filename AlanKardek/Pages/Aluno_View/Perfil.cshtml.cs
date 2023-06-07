using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models.Father;
using AlanKardek.Migrations;

namespace AlanKardek.Pages.Aluno_View
{
    public class PerfilModel : PageModel
    {
        private readonly AlanKardekContext _context;

        public PerfilModel(AlanKardekContext context)
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
            } else if (admin.Tipo != "U")
            {
                return NotFound();
            }

            Admin = admin;

            return Page();
        }

    }
}
