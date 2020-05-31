using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class DiasSemana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaSemana",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Domingo" },
                    { 2, "Segunda-feira" },
                    { 3, "Terça-feira" },
                    { 4, "Quarta-feira" },
                    { 5, "Quinta-feira" },
                    { 6, "Sexta-feira" },
                    { 7, "Sábado" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaSemana",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaSemana",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaSemana",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DiaSemana",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DiaSemana",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DiaSemana",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DiaSemana",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
