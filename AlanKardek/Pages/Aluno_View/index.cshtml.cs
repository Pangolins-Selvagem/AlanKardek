using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models.Father;
using AlanKardek.Migrations;
using AlanKardek.Models;

namespace AlanKardek.Pages.Aluno_View
{
    public class indexModel : PageModel
    {
        private readonly AlanKardekContext _context;

        public indexModel(AlanKardekContext context)
        {
            _context = context;
        }
        public IList<Curso> Curso { get; set; } = default!;
        public Usuario Admin { get; set; } = default!;
        public IList<Usuario> Usuario { get; set; } = default!;
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

            } else if (admin.Tipo != "U")
            {
                return NotFound();
            }

            Admin = admin;

            return Page();
        }

    }
}
