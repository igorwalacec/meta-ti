using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class Funcionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(500)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    IdHemocentro = table.Column<Guid>(nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Hemocentro_IdHemocentro",
                        column: x => x.IdHemocentro,
                        principalTable: "Hemocentro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdHemocentro",
                table: "Funcionario",
                column: "IdHemocentro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
