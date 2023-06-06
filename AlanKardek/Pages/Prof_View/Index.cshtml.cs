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
    public class IndexModel : PageModel
    {
        private readonly AlanKardek.Migrations.AlanKardekContext _context;

        public IndexModel(AlanKardek.Migrations.AlanKardekContext context)
        {
            _context = context;
        }

        public IList<Curso> Curso { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Curso != null)
            {
                Curso = await _context.Curso.ToListAsync();
            }
        }
    }
}
