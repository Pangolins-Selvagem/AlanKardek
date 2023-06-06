using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Migrations;
using AlanKardek.Models;

namespace AlanKardek.Pages.Prof_View
{
    public class DeleteModel : PageModel
    {
        private readonly AlanKardek.Migrations.AlanKardekContext _context;

        public DeleteModel(AlanKardek.Migrations.AlanKardekContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Curso Curso { get; set; } = default!;

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Curso == null)
            {
                return NotFound();
            }
            var curso = await _context.Curso.FindAsync(id);

            if (curso != null)
            {
                Curso = curso;
                _context.Curso.Remove(Curso);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
