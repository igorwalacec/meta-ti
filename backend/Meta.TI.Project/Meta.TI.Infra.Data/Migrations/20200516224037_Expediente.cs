using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class Expediente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expediente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDiaSemana = table.Column<int>(nullable: false),
                    IdHemocentro = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expediente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expediente_DiaSemana_IdDiaSemana",
                        column: x => x.IdDiaSemana,
                        principalTable: "DiaSemana",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expediente_Hemocentro_IdHemocentro",
                        column: x => x.IdHemocentro,
                        principalTable: "Hemocentro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expediente_IdDiaSemana",
                table: "Expediente",
                column: "IdDiaSemana");

            migrationBuilder.CreateIndex(
                name: "IX_Expediente_IdHemocentro",
                table: "Expediente",
                column: "IdHemocentro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expediente");
        }
    }
}
