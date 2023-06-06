using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System.Reflection;
using AlanKardek.Models;
using AlanKardek.Models.Father;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlanKardek.Data.Mappings
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
         public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("tb_cursos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("nm_curso")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

            builder.Property(x => x.Materia)
            .IsRequired()
            .HasColumnName("tx_materia")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20);

            builder.Property(x => x.Descricao)
            .IsRequired()
            .HasColumnName("tx_descricao")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(500);

            builder.Property(x => x.Proprietario)
            .IsRequired()
            .HasColumnName("nm_proprietario")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(220);

            builder.Property(x => x.DataInicio)
            .IsRequired()
            .HasColumnName("dt_curso")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(10);

            builder.Property(x => x.Turma)
            .IsRequired()
            .HasColumnName("tx_turma")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(10);

        }
    }


}
