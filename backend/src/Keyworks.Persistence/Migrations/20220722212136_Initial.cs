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
                name: "SituacaoCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoCards", x => x.Id);
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
                    SituacaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrdemCard = table.Column<int>(type: "INTEGER", nullable: false),
                    PosicaoVertical = table.Column<int>(type: "INTEGER", nullable: false),
                    PosicaoHorizontal = table.Column<int>(type: "INTEGER", nullable: false),
                    SituacaoCardId = table.Column<int>(type: "INTEGER", nullable: true)
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
                        name: "FK_PainelCards_SituacaoCards_SituacaoCardId",
                        column: x => x.SituacaoCardId,
                        principalTable: "SituacaoCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_PainelCards_SituacaoCardId",
                table: "PainelCards",
                column: "SituacaoCardId");
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
        }
    }
}
