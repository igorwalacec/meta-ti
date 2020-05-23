using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class CorrecaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeCompleto",
                table: "Usuario",
                newName: "Sobrenome");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuario",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Usuario",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "Usuario",
                newName: "NomeCompleto");
        }
    }
}
