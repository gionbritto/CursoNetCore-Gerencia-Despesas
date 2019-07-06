using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoDespesas.Migrations
{
    public partial class atualizaMes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ordem",
                table: "TMes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ordem",
                table: "TMes");
        }
    }
}
