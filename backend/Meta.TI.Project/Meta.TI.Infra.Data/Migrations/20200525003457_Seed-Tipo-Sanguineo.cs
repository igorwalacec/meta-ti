using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class SeedTipoSanguineo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTipoLogin",
                table: "Usuario");

            migrationBuilder.InsertData(
                table: "TipoSanguineo",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "A+" },
                    { 2, "A-" },
                    { 3, "AB+" },
                    { 4, "AB-" },
                    { 5, "B+" },
                    { 6, "B-" },
                    { 7, "O+" },
                    { 8, "O-" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipoSanguineo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoSanguineo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoSanguineo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoSanguineo",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TipoSanguineo",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TipoSanguineo",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TipoSanguineo",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TipoSanguineo",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AddColumn<int>(
                name: "IdTipoLogin",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
