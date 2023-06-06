using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AlanKardek.Models.Father;
using AlanKardek.Migrations;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> OnGetAsync()
        {
            var id = HttpContext.Session.GetInt32("USUARIO_ID");
            if (id == null)
            {
                return NotFound();
            }

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
