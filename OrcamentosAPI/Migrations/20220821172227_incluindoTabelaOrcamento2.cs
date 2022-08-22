using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrcamentosAPI.Migrations
{
    public partial class incluindoTabelaOrcamento2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "QtdLivros",
                table: "Orcamentos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtdLivros",
                table: "Orcamentos");
        }
    }
}
