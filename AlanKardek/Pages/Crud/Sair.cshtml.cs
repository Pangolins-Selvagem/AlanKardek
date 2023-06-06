using System;
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

namespace AlanKardek.Pages.Crud
{
    public class SairModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            return Redirect("https://localhost:7132");
        }
    }
}
