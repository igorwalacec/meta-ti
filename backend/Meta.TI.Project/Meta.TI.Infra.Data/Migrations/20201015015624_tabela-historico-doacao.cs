using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class tabelahistoricodoacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoDoacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdHemocentro = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoDoacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoDoacao_Hemocentro_IdHemocentro",
                        column: x => x.IdHemocentro,
                        principalTable: "Hemocentro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoDoacao_IdHemocentro",
                table: "HistoricoDoacao",
                column: "IdHemocentro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoDoacao");
        }
    }
}
