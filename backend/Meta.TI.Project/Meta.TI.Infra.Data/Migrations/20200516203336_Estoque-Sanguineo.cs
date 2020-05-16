using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class EstoqueSanguineo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstoqueSanguineo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoSanguineo = table.Column<int>(nullable: false),
                    IdHemocentro = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueSanguineo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstoqueSanguineo_Hemocentro_IdHemocentro",
                        column: x => x.IdHemocentro,
                        principalTable: "Hemocentro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstoqueSanguineo_TipoSanguineo_IdTipoSanguineo",
                        column: x => x.IdTipoSanguineo,
                        principalTable: "TipoSanguineo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueSanguineo_IdHemocentro",
                table: "EstoqueSanguineo",
                column: "IdHemocentro");

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueSanguineo_IdTipoSanguineo",
                table: "EstoqueSanguineo",
                column: "IdTipoSanguineo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstoqueSanguineo");
        }
    }
}
