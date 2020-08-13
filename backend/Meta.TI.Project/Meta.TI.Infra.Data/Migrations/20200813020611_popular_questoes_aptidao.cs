using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class popular_questoes_aptidao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 7, 2, false, true, 180, "Teve um parto normal nos ultimos 180 dias?" },
                    { 6, 2, false, true, 90, "Teve um parto normal nos ultimos 90 dias?" },
                    { 5, 2, false, true, -1, "Está gravida?" },
                    { 4, null, false, true, 7, "Pegou resfriado dentro dos ultimos 7 dias?" },
                    { 3, null, false, true, -1, "Possui mais que 18 anos?" },
                    { 2, null, false, true, -1, "Possui um peso maior que 50kg?" },
                    { 13, null, false, true, 7, "Extração dentaria nos ultimos 7 dias?" },
                    { 27, null, true, false, -1, "Possui malaria?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "QuestoesAptidao",
                keyColumn: "Id",
                keyValue: 27);
        }
    }
}
