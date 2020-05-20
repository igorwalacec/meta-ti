using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class removetipologin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_TipoLogin_IdTipoLogin",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoLogin");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdTipoLogin",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    SenhaObrigatoria = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLogin", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipoLogin",
                table: "Usuario",
                column: "IdTipoLogin",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_TipoLogin_IdTipoLogin",
                table: "Usuario",
                column: "IdTipoLogin",
                principalTable: "TipoLogin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
