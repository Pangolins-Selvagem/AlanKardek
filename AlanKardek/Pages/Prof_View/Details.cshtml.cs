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
    public class DetailsModel : PageModel
    {
        private readonly AlanKardek.Migrations.AlanKardekContext _context;

        public DetailsModel(AlanKardek.Migrations.AlanKardekContext context)
        {
            _context = context;
        }

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
    }
}
