using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoDespesas.Migrations
{
    public partial class criacaodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TMes",
                columns: table => new
                {
                    MesId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMes", x => x.MesId);
                });

            migrationBuilder.CreateTable(
                name: "TTipoDespesa",
                columns: table => new
                {
                    TipoDespesaId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTipoDespesa", x => x.TipoDespesaId);
                });

            migrationBuilder.CreateTable(
                name: "TSalario",
                columns: table => new
                {
                    SalarioId = table.Column<Guid>(nullable: false),
                    MesId = table.Column<Guid>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSalario", x => x.SalarioId);
                    table.ForeignKey(
                        name: "FK_TSalario_TMes_MesId",
                        column: x => x.MesId,
                        principalTable: "TMes",
                        principalColumn: "MesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TDespesa",
                columns: table => new
                {
                    DespesaId = table.Column<Guid>(nullable: false),
                    MesId = table.Column<Guid>(nullable: false),
                    TipoDespesaId = table.Column<Guid>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDespesa", x => x.DespesaId);
                    table.ForeignKey(
                        name: "FK_TDespesa_TMes_MesId",
                        column: x => x.MesId,
                        principalTable: "TMes",
                        principalColumn: "MesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TDespesa_TTipoDespesa_TipoDespesaId",
                        column: x => x.TipoDespesaId,
                        principalTable: "TTipoDespesa",
                        principalColumn: "TipoDespesaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TDespesa_MesId",
                table: "TDespesa",
                column: "MesId");

            migrationBuilder.CreateIndex(
                name: "IX_TDespesa_TipoDespesaId",
                table: "TDespesa",
                column: "TipoDespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_TSalario_MesId",
                table: "TSalario",
                column: "MesId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TDespesa");

            migrationBuilder.DropTable(
                name: "TSalario");

            migrationBuilder.DropTable(
                name: "TTipoDespesa");

            migrationBuilder.DropTable(
                name: "TMes");
        }
    }
}
