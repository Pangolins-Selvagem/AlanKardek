using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models.Father;
using AlanKardek.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using System;
using AlanKardek.Models;

namespace AlanKardek.Pages.Prof_View;

public class AlunoModel : PageModel
{
    private readonly AlanKardekContext _context;

    public AlunoModel(AlanKardekContext context)
    {
        _context = context;
    }


    public IList<Usuario> Usuario { get; set; } = default!;
    public Usuario Admin { get; set; } = default!;



    [BindProperty]
    public Curso Curso { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (_context.Usuarios != null)
        {
            Usuario = await _context.Usuarios.ToListAsync();
        }

        if (id == null || _context.Curso == null)
        {
            return NotFound();
        }

        var curso = await _context.Curso.FirstOrDefaultAsync(m => m.Id == id);
        if (curso == null)
        {
            return NotFound();
        }
        Curso = curso;


        var ID = HttpContext.Session.GetInt32("USUARIO_ID");

        var admin = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == ID);

        if (_context.Usuarios != null)
        {
            Usuario = await _context.Usuarios.ToListAsync();
        }

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
}
