using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class tabelasaptidao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResultadoAptidao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataResultado = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataProximaDoacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadoAptidao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoAptidao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_Id = table.Column<Guid>(nullable: false),
                    ResultadoAptidao_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAptidao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoAptidao_ResultadoAptidao_ResultadoAptidao_Id",
                        column: x => x.ResultadoAptidao_Id,
                        principalTable: "ResultadoAptidao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoAptidao_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RespostasAptidao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestoesAptidao_Id = table.Column<int>(nullable: false),
                    ResultadoAptidao_Id = table.Column<int>(nullable: false),
                    Resposta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostasAptidao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespostasAptidao_ResultadoAptidao_Id",
                        column: x => x.Id,
                        principalTable: "ResultadoAptidao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RespostasAptidao_QuestoesAptidao_QuestoesAptidao_Id",
                        column: x => x.QuestoesAptidao_Id,
                        principalTable: "QuestoesAptidao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAptidao_ResultadoAptidao_Id",
                table: "HistoricoAptidao",
                column: "ResultadoAptidao_Id");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAptidao_Usuario_Id",
                table: "HistoricoAptidao",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasAptidao_QuestoesAptidao_Id",
                table: "RespostasAptidao",
                column: "QuestoesAptidao_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoAptidao");

            migrationBuilder.DropTable(
                name: "RespostasAptidao");

            migrationBuilder.DropTable(
                name: "ResultadoAptidao");
        }
    }
}
