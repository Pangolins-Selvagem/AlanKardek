using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models;
using AlanKardek.Models.Father;

namespace AlanKardek.Pages.Prof_View
{
    public class EditModel : PageModel
    {
        private readonly AlanKardek.Migrations.AlanKardekContext _context;

        public EditModel(AlanKardek.Migrations.AlanKardekContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Curso Curso { get; set; } = default!;
        public Usuario Admin
        { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Curso == null)
            {
                return NotFound();
            }

            var curso =  await _context.Curso.FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }
            Curso = curso;

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(Curso.Id))
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

        private bool CursoExists(int id)
        {
          return (_context.Curso?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
