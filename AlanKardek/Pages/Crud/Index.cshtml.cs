using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models.Father;
using AlanKardek.Migrations;


namespace AlanKardek.Pages.Crud
{
    public class IndexModel : PageModel
    {
        private readonly AlanKardekContext _context;
        public IndexModel(AlanKardekContext context)
        {
            _context = context;
        }

        public IList<Usuario> Usuario { get; set; } = default!;
        public Usuario Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var id = HttpContext.Session.GetInt32("USUARIO_ID");

            var admin = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);

            if (_context.Usuarios != null)
            {
                Usuario = await _context.Usuarios.ToListAsync();
            }

            if (admin == null)
            {
                return NotFound();
            }
            if (admin.Tipo != "A")
            {

                return NotFound();
            }

            Admin = admin;

            return Page();

        }

    }
}
