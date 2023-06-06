﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models.Father;
using AlanKardek.Migrations;
using Microsoft.AspNetCore.Http;
using AlanKardek.Models;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Mvc.Localization;

namespace AlanKardek.Pages.Crud
{
    public class IndexModel : PageModel
    {
        private readonly AlanKardekContext _context;
        public IndexModel(AlanKardekContext context)
        {
            _context = context;
        }

        public IList<Usuario> Usuario { get; set; } = default!;
        public Usuario Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var id = HttpContext.Session.GetInt32("USUARIO_ID");

            var admin = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);

            if (_context.Usuarios != null)
            {
                Usuario = await _context.Usuarios.ToListAsync();
            }

            if (admin == null)
            {
                return NotFound();
            }

            Admin = admin;

            return Page();

        }

    }
}
