using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class informativosalter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Informativo",
                type: "varchar(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Informativo",
                type: "varchar(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Informativo",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Informativo",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2000)");
        }
    }
}
