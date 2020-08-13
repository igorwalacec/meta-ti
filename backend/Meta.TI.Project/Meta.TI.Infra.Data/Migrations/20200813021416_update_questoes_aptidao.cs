using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class update_questoes_aptidao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 7,
                column: "Pergunta",
                value: "Teve um parto cesario nos ultimos 180 dias?");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 7,
                column: "Pergunta",
                value: "Teve um parto normal nos ultimos 180 dias?");
        }
    }
}
