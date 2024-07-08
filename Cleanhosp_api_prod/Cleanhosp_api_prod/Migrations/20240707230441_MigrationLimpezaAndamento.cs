using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cleanhosp_api_prod.Migrations
{
    /// <inheritdoc />
    public partial class MigrationLimpezaAndamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipamentoId",
                table: "LimpezasAndamento",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "LimpezasAndamento",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipamentoId",
                table: "LimpezasAndamento");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "LimpezasAndamento");
        }
    }
}
