using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class CorrecaoCamposNotificacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdHemocentro",
                table: "Notificacoes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_IdHemocentro",
                table: "Notificacoes",
                column: "IdHemocentro");

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacoes_Hemocentro_IdHemocentro",
                table: "Notificacoes",
                column: "IdHemocentro",
                principalTable: "Hemocentro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notificacoes_Hemocentro_IdHemocentro",
                table: "Notificacoes");

            migrationBuilder.DropIndex(
                name: "IX_Notificacoes_IdHemocentro",
                table: "Notificacoes");

            migrationBuilder.DropColumn(
                name: "IdHemocentro",
                table: "Notificacoes");
        }
    }
}
