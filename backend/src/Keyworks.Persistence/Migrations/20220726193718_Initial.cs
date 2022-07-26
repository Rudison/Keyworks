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
                name: "Paineis",
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
                    table.PrimaryKey("PK_Paineis", x => x.Id);
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
                    PainelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SituacaoCards_Paineis_PainelId",
                        column: x => x.PainelId,
                        principalTable: "Paineis",
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

            migrationBuilder.CreateTable(
                name: "PainelCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false),
                    PainelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainelCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PainelCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PainelCards_Paineis_PainelId",
                        column: x => x.PainelId,
                        principalTable: "Paineis",
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
                table: "Paineis",
                columns: new[] { "Id", "PosicaoHorizontal", "PosicaoVertical", "SituacaoId" },
                values: new object[] { 1, 0, 0, 1 });

            migrationBuilder.InsertData(
                table: "Paineis",
                columns: new[] { "Id", "PosicaoHorizontal", "PosicaoVertical", "SituacaoId" },
                values: new object[] { 2, 1, 0, 2 });

            migrationBuilder.InsertData(
                table: "Paineis",
                columns: new[] { "Id", "PosicaoHorizontal", "PosicaoVertical", "SituacaoId" },
                values: new object[] { 3, 2, 0, 3 });

            migrationBuilder.InsertData(
                table: "Paineis",
                columns: new[] { "Id", "PosicaoHorizontal", "PosicaoVertical", "SituacaoId" },
                values: new object[] { 4, 3, 0, 4 });

            migrationBuilder.InsertData(
                table: "Paineis",
                columns: new[] { "Id", "PosicaoHorizontal", "PosicaoVertical", "SituacaoId" },
                values: new object[] { 5, 4, 0, 4 });

            migrationBuilder.InsertData(
                table: "SituacaoCards",
                columns: new[] { "Id", "Descricao", "PainelId" },
                values: new object[] { 5, "Outros", null });

            migrationBuilder.InsertData(
                table: "SituacaoCards",
                columns: new[] { "Id", "Descricao", "PainelId" },
                values: new object[] { 4, "Finalizado", null });

            migrationBuilder.InsertData(
                table: "SituacaoCards",
                columns: new[] { "Id", "Descricao", "PainelId" },
                values: new object[] { 2, "Em Adamento", null });

            migrationBuilder.InsertData(
                table: "SituacaoCards",
                columns: new[] { "Id", "Descricao", "PainelId" },
                values: new object[] { 1, "Aguardando", null });

            migrationBuilder.InsertData(
                table: "SituacaoCards",
                columns: new[] { "Id", "Descricao", "PainelId" },
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

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DataPrevisao", "Descricao", "Equipe", "NomeProjeto", "Previsto", "Saldo", "SituacaoCardId", "SituacaoId", "StatusCardId", "StatusId", "TituloId" },
                values: new object[] { 1, new DateTime(2022, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usar a branch master, fazer pull", "AS, PH, WC", "CRIAR MIGRATION", new TimeSpan(0, 0, 5, 10, 0), new TimeSpan(0, 0, 5, 5, 0), null, 1, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DataPrevisao", "Descricao", "Equipe", "NomeProjeto", "Previsto", "Saldo", "SituacaoCardId", "SituacaoId", "StatusCardId", "StatusId", "TituloId" },
                values: new object[] { 2, new DateTime(2022, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Criar o select para o relatorio de vendas", "AS, PH, WC", "CRIAR SELECT DO RELATORIO", new TimeSpan(0, 0, 5, 10, 0), new TimeSpan(0, 0, 5, 5, 0), null, 1, null, 2, 1 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DataPrevisao", "Descricao", "Equipe", "NomeProjeto", "Previsto", "Saldo", "SituacaoCardId", "SituacaoId", "StatusCardId", "StatusId", "TituloId" },
                values: new object[] { 3, new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Criar nova hud para pontuacao", "AS, PH, WC", "CRIAR NOVA HUD", new TimeSpan(0, 0, 5, 10, 0), new TimeSpan(0, 0, 5, 5, 0), null, 2, null, 2, 2 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DataPrevisao", "Descricao", "Equipe", "NomeProjeto", "Previsto", "Saldo", "SituacaoCardId", "SituacaoId", "StatusCardId", "StatusId", "TituloId" },
                values: new object[] { 5, new DateTime(2022, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usar a branch master, fazer pull", "AS, PH, WC", "CRIAR MIGRATION", new TimeSpan(0, 0, 5, 10, 0), new TimeSpan(0, 0, 5, 5, 0), null, 3, null, 2, 2 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DataPrevisao", "Descricao", "Equipe", "NomeProjeto", "Previsto", "Saldo", "SituacaoCardId", "SituacaoId", "StatusCardId", "StatusId", "TituloId" },
                values: new object[] { 4, new DateTime(2022, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolver o painel conforme os padroes", "AS, PH, WC", "CRIAR PAINEL DE CONTROLE", new TimeSpan(0, 0, 5, 10, 0), new TimeSpan(0, 0, 5, 5, 0), null, 4, null, 1, 3 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DataPrevisao", "Descricao", "Equipe", "NomeProjeto", "Previsto", "Saldo", "SituacaoCardId", "SituacaoId", "StatusCardId", "StatusId", "TituloId" },
                values: new object[] { 6, new DateTime(2022, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usar a branch master, fazer pull", "AS, PH, WC", "CRIAR MIGRATION", new TimeSpan(0, 0, 5, 10, 0), new TimeSpan(0, 0, 5, 5, 0), null, 2, null, 4, 3 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DataPrevisao", "Descricao", "Equipe", "NomeProjeto", "Previsto", "Saldo", "SituacaoCardId", "SituacaoId", "StatusCardId", "StatusId", "TituloId" },
                values: new object[] { 7, new DateTime(2022, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usar a branch master, fazer pull", "AS, PH, WC", "CRIAR MIGRATION", new TimeSpan(0, 0, 5, 10, 0), new TimeSpan(0, 0, 5, 5, 0), null, 2, null, 4, 3 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DataPrevisao", "Descricao", "Equipe", "NomeProjeto", "Previsto", "Saldo", "SituacaoCardId", "SituacaoId", "StatusCardId", "StatusId", "TituloId" },
                values: new object[] { 8, new DateTime(2022, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usar a branch master, fazer pull", "AS, PH, WC", "CRIAR MIGRATION", new TimeSpan(0, 0, 5, 10, 0), new TimeSpan(0, 0, 5, 5, 0), null, 3, null, 5, 3 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DataPrevisao", "Descricao", "Equipe", "NomeProjeto", "Previsto", "Saldo", "SituacaoCardId", "SituacaoId", "StatusCardId", "StatusId", "TituloId" },
                values: new object[] { 9, new DateTime(2022, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usar a branch master, fazer pull", "AS, PH, WC", "CRIAR MIGRATION", new TimeSpan(0, 0, 5, 10, 0), new TimeSpan(0, 0, 5, 5, 0), null, 3, null, 5, 3 });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "CardId", "PainelId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "CardId", "PainelId" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "CardId", "PainelId" },
                values: new object[] { 3, 3, 2 });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "CardId", "PainelId" },
                values: new object[] { 5, 5, 3 });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "CardId", "PainelId" },
                values: new object[] { 4, 4, 4 });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "CardId", "PainelId" },
                values: new object[] { 6, 6, 4 });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "CardId", "PainelId" },
                values: new object[] { 7, 7, 4 });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "CardId", "PainelId" },
                values: new object[] { 8, 8, 4 });

            migrationBuilder.InsertData(
                table: "PainelCards",
                columns: new[] { "Id", "CardId", "PainelId" },
                values: new object[] { 9, 9, 5 });

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
                name: "IX_PainelCards_CardId",
                table: "PainelCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_PainelCards_PainelId",
                table: "PainelCards",
                column: "PainelId");

            migrationBuilder.CreateIndex(
                name: "IX_SituacaoCards_PainelId",
                table: "SituacaoCards",
                column: "PainelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "PainelCards");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "SituacaoCards");

            migrationBuilder.DropTable(
                name: "StatusCards");

            migrationBuilder.DropTable(
                name: "Titulos");

            migrationBuilder.DropTable(
                name: "Paineis");
        }
    }
}
