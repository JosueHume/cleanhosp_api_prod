using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cleanhosp_api_prod.Migrations
{
    /// <inheritdoc />
    public partial class _07072024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LimpezasAndamento_Alas_AlaId",
                table: "LimpezasAndamento");

            migrationBuilder.DropForeignKey(
                name: "FK_LimpezasAndamento_Limpezas_LimpezaId",
                table: "LimpezasAndamento");

            migrationBuilder.DropForeignKey(
                name: "FK_LimpezasAndamento_Pessoas_PessoaId",
                table: "LimpezasAndamento");

            migrationBuilder.RenameColumn(
                name: "AlaId",
                table: "LimpezasAndamento",
                newName: "LocalId");

            migrationBuilder.RenameIndex(
                name: "IX_LimpezasAndamento_AlaId",
                table: "LimpezasAndamento",
                newName: "IX_LimpezasAndamento_LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_LimpezasAndamento_Limpezas_LimpezaId",
                table: "LimpezasAndamento",
                column: "LimpezaId",
                principalTable: "Limpezas",
                principalColumn: "LimpezaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LimpezasAndamento_Locais_LocalId",
                table: "LimpezasAndamento",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "LocalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LimpezasAndamento_Pessoas_PessoaId",
                table: "LimpezasAndamento",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LimpezasAndamento_Limpezas_LimpezaId",
                table: "LimpezasAndamento");

            migrationBuilder.DropForeignKey(
                name: "FK_LimpezasAndamento_Locais_LocalId",
                table: "LimpezasAndamento");

            migrationBuilder.DropForeignKey(
                name: "FK_LimpezasAndamento_Pessoas_PessoaId",
                table: "LimpezasAndamento");

            migrationBuilder.RenameColumn(
                name: "LocalId",
                table: "LimpezasAndamento",
                newName: "AlaId");

            migrationBuilder.RenameIndex(
                name: "IX_LimpezasAndamento_LocalId",
                table: "LimpezasAndamento",
                newName: "IX_LimpezasAndamento_AlaId");

            migrationBuilder.AddForeignKey(
                name: "FK_LimpezasAndamento_Alas_AlaId",
                table: "LimpezasAndamento",
                column: "AlaId",
                principalTable: "Alas",
                principalColumn: "AlaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LimpezasAndamento_Limpezas_LimpezaId",
                table: "LimpezasAndamento",
                column: "LimpezaId",
                principalTable: "Limpezas",
                principalColumn: "LimpezaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LimpezasAndamento_Pessoas_PessoaId",
                table: "LimpezasAndamento",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
