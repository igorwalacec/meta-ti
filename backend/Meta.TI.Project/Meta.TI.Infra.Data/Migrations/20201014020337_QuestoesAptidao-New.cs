using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class QuestoesAptidaoNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestoesAptidao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pergunta = table.Column<string>(type: "varchar(255)", nullable: false),
                    NumeroDiasAfastado = table.Column<int>(type: "int", nullable: false),
                    ImpeditivoDefinitivo = table.Column<bool>(type: "bit", nullable: false),
                    ImpeditivoDeterminado = table.Column<bool>(type: "bit", nullable: false),
                    IdTipoSexo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestoesAptidao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestoesAptidao_TipoSexo_IdTipoSexo",
                        column: x => x.IdTipoSexo,
                        principalTable: "TipoSexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResultadoAptidao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataResultado = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataProximaDoacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DiasAfastados = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "QuestoesAptidao",
                columns: new[] { "Id", "IdTipoSexo", "ImpeditivoDefinitivo", "ImpeditivoDeterminado", "NumeroDiasAfastado", "Pergunta" },
                values: new object[,]
                {
                    { 1, null, false, true, -1, "Boas condições de saúde" },
                    { 25, null, true, false, -1, "Possui evidencias clinicas ou laboratoriais de doenças infecciosas trasmissiveis pelo sangue?" },
                    { 24, null, true, false, -1, "Possui hepatite desde os 11 anos?" },
                    { 23, null, false, true, 183, "Caso possuia febre amarela, fazem 6 meses após a recuperação completa?" },
                    { 22, null, false, true, 30, "Esteve em região de surto de febre amarela ou tomou a vacina após o retorno?" },
                    { 21, null, false, true, 365, "Esteve em paises com alta prevalencia de malaria?" },
                    { 20, null, false, true, 30, "Esteve nos EUA nos últimos 30 dias?" },
                    { 19, null, false, true, 365, "Esteve no Acre, Amapa, Amazonas, Rondonia, Roraima, Maranhão, Mato Grosso, Para e Tocantins nos ultimos 12 meses?" },
                    { 18, null, false, true, -1, "Possui herpes zoster?" },
                    { 17, null, false, true, -1, "Possui herpes labial ou genital?" },
                    { 16, null, false, true, 2, "Vácina contra gripe nas últimas 48 horas?" },
                    { 15, null, false, true, 1, "Acumpuntura com material descartável nas ultimas 24 horas?" },
                    { 26, null, true, false, -1, "Usa drogas ilicitas injetaveis?" },
                    { 14, null, false, true, 30, "Cirurgia odontologica com anestesia geral nas últimas 4 semanas?" },
                    { 12, null, false, true, 183, "Passou por procedimentos endoscópico nos últimos 6 meses?" },
                    { 11, null, false, true, 365, "Situações nas quais há maior risco de contrair doenças sexualmente transmissiveis?" },
                    { 10, null, false, true, 365, "Fez tatuagem ou maquiagem definitiva nos últimos 12 meses?" },
                    { 9, null, false, true, 1, "Ingeriu bebidas alcoolicas nas últimas 12 horas?" },
                    { 8, 2, false, true, -1, "Está em periodo de amamentação?" },
                    { 7, 2, false, true, 180, "Teve um parto cesario nos ultimos 180 dias?" },
                    { 6, 2, false, true, 90, "Teve um parto normal nos ultimos 90 dias?" },
                    { 5, 2, false, true, -1, "Está gravida?" },
                    { 4, null, false, true, 7, "Pegou resfriado dentro dos ultimos 7 dias?" },
                    { 3, null, false, true, -1, "Possui mais que 18 anos?" },
                    { 2, null, false, true, -1, "Possui um peso maior que 50kg?" },
                    { 13, null, false, true, 7, "Extração dentaria nos ultimos 7 dias?" },
                    { 27, null, true, false, -1, "Possui malaria?" }
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
                name: "IX_QuestoesAptidao_IdTipoSexo",
                table: "QuestoesAptidao",
                column: "IdTipoSexo");

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

            migrationBuilder.DropTable(
                name: "QuestoesAptidao");
        }
    }
}
