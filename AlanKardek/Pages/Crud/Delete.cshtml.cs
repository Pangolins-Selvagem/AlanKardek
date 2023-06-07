using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models.Father;
using AlanKardek.Migrations;

namespace AlanKardek.Pages.Crud
{
    public class DeleteModel : PageModel
    {
        private readonly AlanKardekContext _context;

        public DeleteModel(AlanKardekContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;
        public Usuario Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var ID = HttpContext.Session.GetInt32("USUARIO_ID");

            if (id == null || _context.Usuarios == null || ID == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }
            else 
            {
                Usuario = usuario;
            }

            var admin = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == ID);

            if (admin == null)
            {
                return NotFound();

            } else if (admin.Tipo != "A" &&(admin.Privilegiado != "S"))
            {
                return NotFound();
            }
            Admin = admin;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario != null)
            {
                Usuario = usuario;
                _context.Usuarios.Remove(Usuario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
