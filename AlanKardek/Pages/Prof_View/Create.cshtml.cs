using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlanKardek.Models;
using AlanKardek.Models.Father;
using Microsoft.EntityFrameworkCore;

namespace AlanKardek.Pages.Prof_View
{
    public class CreateModel : PageModel
    {
        private readonly AlanKardek.Migrations.AlanKardekContext _context;

        public CreateModel(AlanKardek.Migrations.AlanKardekContext context)
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
            if (admin.Tipo != "P")
            {

                return NotFound();
            }

            Admin = admin;

            return Page();

        }


        [BindProperty]
        public Curso Curso { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Curso == null || Curso == null)
            {
                return Page();
            }

            _context.Curso.Add(Curso);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
