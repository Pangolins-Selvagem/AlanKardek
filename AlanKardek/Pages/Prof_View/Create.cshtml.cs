using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AlanKardek.Migrations;
using AlanKardek.Models;

namespace AlanKardek.Pages.Prof_View
{
    public class CreateModel : PageModel
    {
        private readonly AlanKardek.Migrations.AlanKardekContext _context;

        public CreateModel(AlanKardek.Migrations.AlanKardekContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
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
