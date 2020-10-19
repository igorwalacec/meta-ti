using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class NovasColunasEstoqueSanguineo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QtdBolsas",
                table: "EstoqueSanguineo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QtdMinimaBolsas",
                table: "EstoqueSanguineo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtdBolsas",
                table: "EstoqueSanguineo");

            migrationBuilder.DropColumn(
                name: "QtdMinimaBolsas",
                table: "EstoqueSanguineo");
        }
    }
}
