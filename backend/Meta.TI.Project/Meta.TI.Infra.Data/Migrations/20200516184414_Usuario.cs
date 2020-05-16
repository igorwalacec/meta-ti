using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(255)", nullable: true),
                    RG = table.Column<string>(name: "RG)", type: "varchar(255)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(255)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    IdTipoSanguineo = table.Column<int>(nullable: true),
                    IdEndereco = table.Column<int>(nullable: false),
                    IdTipoLogin = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Endereco_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoLogin_IdTipoLogin",
                        column: x => x.IdTipoLogin,
                        principalTable: "TipoLogin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoSanguineo_IdTipoSanguineo",
                        column: x => x.IdTipoSanguineo,
                        principalTable: "TipoSanguineo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdEndereco",
                table: "Usuario",
                column: "IdEndereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipoLogin",
                table: "Usuario",
                column: "IdTipoLogin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipoSanguineo",
                table: "Usuario",
                column: "IdTipoSanguineo",
                unique: true,
                filter: "[IdTipoSanguineo] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
