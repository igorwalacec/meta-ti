using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class CreateTableFeedSolicitacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedSolicitacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHemocentro = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    IdTipoSanguineo = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedSolicitacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedSolicitacao_Hemocentro_IdHemocentro",
                        column: x => x.IdHemocentro,
                        principalTable: "Hemocentro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FeedSolicitacao_TipoSanguineo_IdTipoSanguineo",
                        column: x => x.IdTipoSanguineo,
                        principalTable: "TipoSanguineo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FeedSolicitacao_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedSolicitacao_IdHemocentro",
                table: "FeedSolicitacao",
                column: "IdHemocentro");

            migrationBuilder.CreateIndex(
                name: "IX_FeedSolicitacao_IdTipoSanguineo",
                table: "FeedSolicitacao",
                column: "IdTipoSanguineo");

            migrationBuilder.CreateIndex(
                name: "IX_FeedSolicitacao_IdUsuario",
                table: "FeedSolicitacao",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedSolicitacao");
        }
    }
}
