using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.TI.Infra.Data.Migrations
{
    public partial class tabelaorientacaodoacaostatusdoacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdStatus",
                table: "ResultadoAptidao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrientacaoDoacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orientacao = table.Column<string>(type: "varchar(1500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrientacaoDoacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusDoacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusDoacao", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OrientacaoDoacao",
                columns: new[] { "Id", "Orientacao" },
                values: new object[,]
                {
                    { 1, "Estar em boas condições de saúde." },
                    { 2, "Ter entre 16 e 69 anos, desde que a primeira doação tenha sido feita até 60 anos (menores de 18 anos)." },
                    { 3, "Pesar no minimo 50Kg." },
                    { 4, "Estar descansado (ter dormido pelo menos 6 horas nas últimas 24 horas)." },
                    { 5, "Estar alimentado (evitar alimentação gordurosa nas 4 horas que antecedem a doação)." },
                    { 6, "Apresentar documento original com foto recente, que permita a identificação do usuario (Carteira de Identidade, Cartão de Identidade de Profissional Liberal, Carteira de Trabalho e Previdência Social, Carteira nacional de Habilitação e RNE-Registro Nacional de Estrangeiro)." }
                });

            migrationBuilder.InsertData(
                table: "StatusDoacao",
                columns: new[] { "Id", "Descricao", "IdStatus" },
                values: new object[,]
                {
                    { 1, "Apto para doar", 1 },
                    { 2, "Não apto para doar", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoAptidao_IdStatus",
                table: "ResultadoAptidao",
                column: "IdStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoAptidao_StatusDoacao_IdStatus",
                table: "ResultadoAptidao",
                column: "IdStatus",
                principalTable: "StatusDoacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoAptidao_StatusDoacao_IdStatus",
                table: "ResultadoAptidao");

            migrationBuilder.DropTable(
                name: "OrientacaoDoacao");

            migrationBuilder.DropTable(
                name: "StatusDoacao");

            migrationBuilder.DropIndex(
                name: "IX_ResultadoAptidao_IdStatus",
                table: "ResultadoAptidao");

            migrationBuilder.DropColumn(
                name: "IdStatus",
                table: "ResultadoAptidao");
        }
    }
}
