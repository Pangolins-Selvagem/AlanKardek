﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;  

namespace AlanKardek.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string? Mensagem = null;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            var mensagem = HttpContext.Session.GetString("MENSAGEM");
            if(mensagem == null){

                return Page();
            }
            Mensagem = mensagem;
            return Page();
        }

        public void OnPost()
        {
            HttpContext.Session.Clear();
        }

    }

}