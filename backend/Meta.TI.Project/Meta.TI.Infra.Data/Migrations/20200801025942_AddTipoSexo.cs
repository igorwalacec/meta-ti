using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class AddTipoSexo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdTipoSanguineo",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "IdTipoSexo",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoSexo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSexo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TipoSexo",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 1, "Masculino" });

            migrationBuilder.InsertData(
                table: "TipoSexo",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 2, "Feminino" });

            migrationBuilder.InsertData(
                table: "TipoSexo",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 3, "Outros" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipoSanguineo",
                table: "Usuario",
                column: "IdTipoSanguineo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipoSexo",
                table: "Usuario",
                column: "IdTipoSexo");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_TipoSexo_IdTipoSexo",
                table: "Usuario",
                column: "IdTipoSexo",
                principalTable: "TipoSexo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_TipoSexo_IdTipoSexo",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoSexo");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdTipoSanguineo",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdTipoSexo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdTipoSexo",
                table: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipoSanguineo",
                table: "Usuario",
                column: "IdTipoSanguineo",
                unique: true,
                filter: "[IdTipoSanguineo] IS NOT NULL");
        }
    }
}
