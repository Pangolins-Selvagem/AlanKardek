using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models.Father;
using AlanKardek.Migrations;

namespace AlanKardek.Pages.Crud
{
    public class EditModel : PageModel
    {
        private readonly AlanKardekContext _context;

        public EditModel(AlanKardekContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;
        public Usuario Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario =  await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            Usuario = usuario;

            var ID = HttpContext.Session.GetInt32("USUARIO_ID");

            var admin = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == ID);

            if (admin == null)
            {
                return NotFound();
            }

            Admin = admin;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var ID = HttpContext.Session.GetInt32("USUARIO_ID");

            var admin = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == ID);

            if (admin == null)
            {
                return NotFound();
            }

            Admin = admin;

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _context.Attach(Usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(Usuario.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
