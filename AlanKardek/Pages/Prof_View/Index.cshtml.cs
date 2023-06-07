using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models.Father;
using AlanKardek.Models;

namespace AlanKardek.Pages.Prof_View
{
    public class IndexModel : PageModel
    {
        private readonly AlanKardek.Migrations.AlanKardekContext _context;

        public IndexModel(AlanKardek.Migrations.AlanKardekContext context)
        {
            _context = context;
        }

        public IList<Curso> Curso { get;set; } = default!;
        public Usuario Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {

            if (_context.Curso != null)
            {
                Curso = await _context.Curso.ToListAsync();
            }

            var id = HttpContext.Session.GetInt32("USUARIO_ID");

            var admin = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);

            if (admin == null)
            {
                return NotFound();

            } else if (admin.Tipo != "P"){

                return NotFound();
            }

            Admin = admin;

            return Page();
        }
    }
}
