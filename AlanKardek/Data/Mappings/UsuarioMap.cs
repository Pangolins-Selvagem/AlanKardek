using AlanKardek.Models.Father;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlanKardek.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb_usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("nm_usuario")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

            builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("tx_email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

            builder.Property(x => x.Senha)
            .IsRequired()
            .HasColumnName("tx_senha")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(10);

            builder.Property(x => x.Tipo)
            .IsRequired()
            .HasColumnName("tp_usuario")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(1);

            builder.Property(x => x.Privilegiado)
            .IsRequired()
            .HasColumnName("in_privilegiado")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(1);

            builder.Property(x => x.Turma)
           .IsRequired()
           .HasColumnName("tx_turma")
           .HasColumnType("NVARCHAR")
           .HasMaxLength(10);

        }
    }
}
