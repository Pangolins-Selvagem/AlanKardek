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
            if(email == null)
            {
                return NotFound();
            }
            if(_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Email == email);
            if (usuario == null)
            {
                Mensagem = "Usuário não encontrado!";
                HttpContext.Session.SetString("MENSAGEMS", Mensagem);
                return RedirectToPage("./Senha_E");
            }
            Usuario = usuario;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Mensagem = "Por favor colocar uma nova senha !";
                return Page();
            }

            _context.Attach(Usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(Usuario.Id))
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

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
