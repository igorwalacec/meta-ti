using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class tabelarecompensalevelpatrocinador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patrocinador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePatrocinador = table.Column<string>(type: "varchar(255)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrocinador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recompensas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(255)", nullable: false),
                    IdPatrocinador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recompensas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recompensas_Patrocinador_IdPatrocinador",
                        column: x => x.IdPatrocinador,
                        principalTable: "Patrocinador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    QuantidadeDoacao = table.Column<int>(type: "int", nullable: false),
                    IdRecompensas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Level_Recompensas_IdRecompensas",
                        column: x => x.IdRecompensas,
                        principalTable: "Recompensas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Level_IdRecompensas",
                table: "Level",
                column: "IdRecompensas",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recompensas_IdPatrocinador",
                table: "Recompensas",
                column: "IdPatrocinador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "Recompensas");

            migrationBuilder.DropTable(
                name: "Patrocinador");
        }
    }
}
