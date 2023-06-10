using AlanKardek.Migrations;
using AlanKardek.Models.Father;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlanKardek.Pages.Shared

{
    public class _Layout : PageModel
    {
        private readonly AlanKardekContext _context;

        public _Layout(AlanKardekContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var ID = HttpContext.Session.GetInt32("USUARIO_ID");

            var admin = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == ID);

            if (admin == null)
            {
                return NotFound();
            }

            Admin = admin;

            return Page();
        }

        private IActionResult Page()
        {
            throw new NotImplementedException();
        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
