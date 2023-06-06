using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlanKardek.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nm_curso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tx_materia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tx_descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nm_proprietario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dt_curso = table.Column<string>(type: "nvarchar(max)", maxLength: 10, nullable: false),
                    tx_turma = table.Column<string>(type: "nvarchar(max)", maxLength: 10, nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nm_usuario = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    tx_email = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    tx_senha = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false),
                    tp_usuario = table.Column<string>(type: "NVARCHAR(1)", maxLength: 1, nullable: false),
                    in_privilegiado = table.Column<string>(type: "NVARCHAR(1)", maxLength: 1, nullable: false),
                    tx_turma = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cursos");

            migrationBuilder.DropTable(
                name: "tb_usuario");
        }
    }
}
