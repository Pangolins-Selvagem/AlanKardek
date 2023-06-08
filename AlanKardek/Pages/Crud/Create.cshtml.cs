using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlanKardek.Models.Father;
using AlanKardek.Migrations;
using Microsoft.EntityFrameworkCore;

namespace AlanKardek.Pages.Crud
{
    public class CreateModel : PageModel
    {
        private readonly AlanKardekContext _context;

        public CreateModel(AlanKardekContext context)
        {
            _context = context;
        }
        public Usuario Admin { get; set; } = default!;
        public string? mensagem = null;

        public async Task<IActionResult> OnGetAsync()
        {
            var id = HttpContext.Session.GetInt32("USUARIO_ID");

            var admin = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);

            if (admin == null)
            {
                return NotFound();
            }

            Admin = admin;

            return Page();
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var id = HttpContext.Session.GetInt32("USUARIO_ID");
            if(id == null)
            {
                return NotFound();
            }

            var admin = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);

            if (admin == null)
            {
                return Page();
            }

            Admin = admin;

            if (!ModelState.IsValid || _context.Usuarios == null || Usuario == null)
            {
                return Page();
            }

            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

        }
    }
}
