using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Keyworks.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PainelCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SituacaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PosicaoVertical = table.Column<int>(type: "INTEGER", nullable: false),
                    PosicaoHorizontal = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainelCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacaoCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    PainelCardsId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SituacaoCards_PainelCards_PainelCardsId",
                        column: x => x.PainelCardsId,
                        principalTable: "PainelCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TituloId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    SituacaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    NomeProjeto = table.Column<string>(type: "TEXT", nullable: true),
                    DataPrevisao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Previsto = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Saldo = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Equipe = table.Column<string>(type: "TEXT", nullable: true),
                    StatusCardId = table.Column<int>(type: "INTEGER", nullable: true),
                    SituacaoCardId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_SituacaoCards_SituacaoCardId",
                        column: x => x.SituacaoCardId,
                        principalTable: "SituacaoCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_StatusCards_StatusCardId",
                        column: x => x.StatusCardId,
                        principalTable: "StatusCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_Titulos_TituloId",
                        column: x => x.TituloId,
                        principalTable: "Titulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colaboradores",
                columns: new[] { "Id", "Nome", "Sobrenome" },
                values: new object[] { 1, "Afonso", "Solano" });

            migrationBuilder.InsertData(
                table: "Colaboradores",
                columns: new[] { "Id", "Nome", "Sobrenome" },
                values: new object[] { 2, "Pedro", "Henrique" });

            migrationBuilder.InsertData(
                table: "Colaboradores",
                columns: new[] { "Id", "Nome", "Sobrenome" },
                values: new object[] { 3, "Wellington", "Oliveira" });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "PosicaoHorizontal", "PosicaoVertical", "SituacaoId" },
                values: new object[] { 1, 0, 0, 1 });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "PosicaoHorizontal", "PosicaoVertical", "SituacaoId" },
                values: new object[] { 2, 1, 0, 2 });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "PosicaoHorizontal", "PosicaoVertical", "SituacaoId" },
                values: new object[] { 3, 2, 0, 3 });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "PosicaoHorizontal", "PosicaoVertical", "SituacaoId" },
                values: new object[] { 4, 3, 0, 4 });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "PosicaoHorizontal", "PosicaoVertical", "SituacaoId" },
                values: new object[] { 5, 4, 0, 4 });

            migrationBuilder.InsertData(
                table: "SituacaoCards",
                columns: new[] { "Id", "Descricao", "PainelCardsId" },
                values: new object[] { 5, "Outros", null });

            migrationBuilder.InsertData(
                table: "SituacaoCards",
                columns: new[] { "Id", "Descricao", "PainelCardsId" },
                values: new object[] { 4, "Finalizado", null });

            migrationBuilder.InsertData(
                table: "SituacaoCards",
                columns: new[] { "Id", "Descricao", "PainelCardsId" },
                values: new object[] { 2, "Em Adamento", null });

            migrationBuilder.InsertData(
                table: "SituacaoCards",
                columns: new[] { "Id", "Descricao", "PainelCardsId" },
                values: new object[] { 1, "Aguardando", null });

            migrationBuilder.InsertData(
                table: "SituacaoCards",
                columns: new[] { "Id", "Descricao", "PainelCardsId" },
                values: new object[] { 3, "Pendência", null });

            migrationBuilder.InsertData(
                table: "StatusCards",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 1, "Em Dia" });

            migrationBuilder.InsertData(
                table: "StatusCards",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 2, "Atenção" });

            migrationBuilder.InsertData(
                table: "StatusCards",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 3, "Em Atraso" });

            migrationBuilder.InsertData(
                table: "Titulos",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 2, "UX|UI" });

            migrationBuilder.InsertData(
                table: "Titulos",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 1, "Desenvolvimento" });

            migrationBuilder.InsertData(
                table: "Titulos",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 3, "Financeiro" });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SituacaoCardId",
                table: "Cards",
                column: "SituacaoCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_StatusCardId",
                table: "Cards",
                column: "StatusCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TituloId",
                table: "Cards",
                column: "TituloId");

            migrationBuilder.CreateIndex(
                name: "IX_SituacaoCards_PainelCardsId",
                table: "SituacaoCards",
                column: "PainelCardsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "SituacaoCards");

            migrationBuilder.DropTable(
                name: "StatusCards");

            migrationBuilder.DropTable(
                name: "Titulos");

            migrationBuilder.DropTable(
                name: "PainelCards");
        }
    }
}
