using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cleanhosp_api_prod.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alas",
                columns: table => new
                {
                    AlaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alas", x => x.AlaId);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    EquipamentoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Marca = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Modelo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DataAquisicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ValorAquisicao = table.Column<decimal>(type: "numeric", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.EquipamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Limpezas",
                columns: table => new
                {
                    LimpezaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limpezas", x => x.LimpezaId);
                });

            migrationBuilder.CreateTable(
                name: "Locais",
                columns: table => new
                {
                    LocalId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AlaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.LocalId);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Login = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Marca = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    QtdeEstoque = table.Column<int>(type: "integer", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "LimpezasAndamento",
                columns: table => new
                {
                    LimpezaAndamentoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlaId = table.Column<int>(type: "integer", nullable: false),
                    PessoaId = table.Column<int>(type: "integer", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataFim = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LimpezaId = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Finalizado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LimpezasAndamento", x => x.LimpezaAndamentoId);
                    table.ForeignKey(
                        name: "FK_LimpezasAndamento_Alas_AlaId",
                        column: x => x.AlaId,
                        principalTable: "Alas",
                        principalColumn: "AlaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LimpezasAndamento_Limpezas_LimpezaId",
                        column: x => x.LimpezaId,
                        principalTable: "Limpezas",
                        principalColumn: "LimpezaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LimpezasAndamento_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipamentosUtilizados",
                columns: table => new
                {
                    EquipamentosUtilizadosId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TempoUsoEmMinutos = table.Column<int>(type: "integer", nullable: false),
                    EquipamentoId = table.Column<int>(type: "integer", nullable: false),
                    LimpezaAndamentoId = table.Column<int>(type: "integer", nullable: false),
                    LimpezaAndamentoId1 = table.Column<int>(type: "integer", nullable: false),
                    LimpezaAndamentoId2 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentosUtilizados", x => x.EquipamentosUtilizadosId);
                    table.ForeignKey(
                        name: "FK_EquipamentosUtilizados_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "EquipamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipamentosUtilizados_LimpezasAndamento_LimpezaAndamentoId",
                        column: x => x.LimpezaAndamentoId,
                        principalTable: "LimpezasAndamento",
                        principalColumn: "LimpezaAndamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipamentosUtilizados_LimpezasAndamento_LimpezaAndamentoId1",
                        column: x => x.LimpezaAndamentoId1,
                        principalTable: "LimpezasAndamento",
                        principalColumn: "LimpezaAndamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosUtilizados",
                columns: table => new
                {
                    ProdutosUtilizadosId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    LimpezaAndamentoId = table.Column<int>(type: "integer", nullable: false),
                    LimpezaAndamentoId1 = table.Column<int>(type: "integer", nullable: false),
                    LimpezaAndamentoId2 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosUtilizados", x => x.ProdutosUtilizadosId);
                    table.ForeignKey(
                        name: "FK_ProdutosUtilizados_LimpezasAndamento_LimpezaAndamentoId",
                        column: x => x.LimpezaAndamentoId,
                        principalTable: "LimpezasAndamento",
                        principalColumn: "LimpezaAndamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosUtilizados_LimpezasAndamento_LimpezaAndamentoId1",
                        column: x => x.LimpezaAndamentoId1,
                        principalTable: "LimpezasAndamento",
                        principalColumn: "LimpezaAndamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosUtilizados_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentosUtilizados_EquipamentoId",
                table: "EquipamentosUtilizados",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentosUtilizados_LimpezaAndamentoId",
                table: "EquipamentosUtilizados",
                column: "LimpezaAndamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentosUtilizados_LimpezaAndamentoId1",
                table: "EquipamentosUtilizados",
                column: "LimpezaAndamentoId1");

            migrationBuilder.CreateIndex(
                name: "IX_LimpezasAndamento_AlaId",
                table: "LimpezasAndamento",
                column: "AlaId");

            migrationBuilder.CreateIndex(
                name: "IX_LimpezasAndamento_LimpezaId",
                table: "LimpezasAndamento",
                column: "LimpezaId");

            migrationBuilder.CreateIndex(
                name: "IX_LimpezasAndamento_PessoaId",
                table: "LimpezasAndamento",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosUtilizados_LimpezaAndamentoId",
                table: "ProdutosUtilizados",
                column: "LimpezaAndamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosUtilizados_LimpezaAndamentoId1",
                table: "ProdutosUtilizados",
                column: "LimpezaAndamentoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosUtilizados_ProdutoId",
                table: "ProdutosUtilizados",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipamentosUtilizados");

            migrationBuilder.DropTable(
                name: "Locais");

            migrationBuilder.DropTable(
                name: "ProdutosUtilizados");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "LimpezasAndamento");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Alas");

            migrationBuilder.DropTable(
                name: "Limpezas");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
