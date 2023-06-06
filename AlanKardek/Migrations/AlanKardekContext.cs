using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models;
using AlanKardek.Models.Father;
using AlanKardek.Data.Mappings;

namespace AlanKardek.Migrations
{
    public class AlanKardekContext : DbContext
    {
        public AlanKardekContext(DbContextOptions<AlanKardekContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Curso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
        }
    }
}
