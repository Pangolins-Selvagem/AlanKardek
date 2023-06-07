using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models;
using AlanKardek.Models.Father;

namespace AlanKardek.Pages.Prof_View
{
    public class DetailsModel : PageModel
    {
        private readonly AlanKardek.Migrations.AlanKardekContext _context;

        public DetailsModel(AlanKardek.Migrations.AlanKardekContext context)
        {
            _context = context;
        }

      public Curso Curso { get; set; } = default!;
      public Usuario Admin { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Curso == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso.FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }
            else 
            {
                Curso = curso;
            }

            var ID = HttpContext.Session.GetInt32("USUARIO_ID");

            var admin = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == ID);

            if (admin == null)
            {
                return NotFound();

            }
            else if (admin.Tipo != "P")
            {

                return NotFound();
            }

            Admin = admin;

            return Page();
        }
    }
}
