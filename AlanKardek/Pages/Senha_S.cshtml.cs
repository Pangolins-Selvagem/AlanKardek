using AlanKardek.Migrations;
using AlanKardek.Models.Father;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlanKardek.Pages
{
    public class Senha_SModel : PageModel
    {
        private readonly AlanKardekContext _context;

        public Senha_SModel(AlanKardekContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;
        public string? Mensagem { get; set; } = null;
        public async Task<IActionResult> OnGetAsync(String? email)
        {
            if(email == null || _context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Email == email);
            if (usuario == null)
            {
                Mensagem = "Usuário não encontrado!";
                HttpContext.Session.SetString("MENSAGEM", Mensagem);
                return RedirectToPage("./Senha_E");
            }
            Usuario = usuario;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _context.Attach(Usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(Usuario.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect("https://localhost:7132");
        }

        private bool UsuarioExists(string email)
        {
            return (_context.Usuarios?.Any(e => e.Email == email)).GetValueOrDefault();
        }

    }
}
