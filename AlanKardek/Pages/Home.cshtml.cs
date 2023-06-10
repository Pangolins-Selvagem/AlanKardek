using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models.Father;
using AlanKardek.Migrations;

namespace AlanKardek.Pages
{
    public class HomeModel : PageModel
    {
        private readonly AlanKardekContext _context;

        public HomeModel(AlanKardekContext context)
        {
            _context = context;
        }

        public Usuario? Usuario { get; set; } = null!;
        public string? Mensagem = null;

        public async Task<IActionResult> OnGetAsync(String email, String senha)
        {
            if (email == "" || senha == "") return NotFound();

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Email == email);

            if (usuario == null)
            {
                Mensagem = "Usuário ou senha invalidos !";
                HttpContext.Session.SetString("MENSAGEM", Mensagem);
                return RedirectToPage("./Index");
            }
            else
            {
                if (usuario.Senha != senha)
                {
                    Mensagem = "Usuário ou senha invalidos !";
                    HttpContext.Session.SetString("MENSAGEM", Mensagem);
                    return RedirectToPage("./Index");
                }
                else
                {
                    if (usuario.Situacao == "Inativo")
                    {
                        Mensagem = "Por favor troque a senha antes de entrar ! ";
                        HttpContext.Session.SetString("MENSAGEM", Mensagem);
                        return RedirectToPage("./Index");

                    }
                    else
                    {
                        Usuario = usuario;

                        if (string.IsNullOrEmpty(HttpContext.Session.GetString("USUARIO_NOME")))
                        {
                            HttpContext.Session.SetString("USUARIO_NOME", usuario.Nome);
                            HttpContext.Session.SetInt32("USUARIO_ID", usuario.Id);
                        }

                        // recupera o usuario da sessao     Usuario u = HttpContext.Session.Get("USUARIO_GLOBAL");

                        // limpa a sessao     HttpContext.Session.Clear();


                        if (usuario.Tipo.ToUpper() == "U")
                        {

                            return RedirectToPage("./Aluno_View/index");
                        }
                        else
                        {
                            if (usuario.Tipo.ToUpper() == "A")
                            {
                                return RedirectToPage("./Crud/Index");
                            }

                            else
                            {
                                return RedirectToPage("./Prof_View");
                            }




                        }
                    }
                }
                return Page();
            }
        }
    }
}
