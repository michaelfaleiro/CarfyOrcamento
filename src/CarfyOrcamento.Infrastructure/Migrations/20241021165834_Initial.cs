using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarfyOrcamento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeRazaoSocial = table.Column<string>(type: "text", nullable: false),
                    NomeFantasia = table.Column<string>(type: "text", nullable: false),
                    CpfCnpj = table.Column<string>(type: "text", nullable: false),
                    RgIe = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    TipoPessoa = table.Column<int>(type: "integer", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Logradouro = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    Complemento = table.Column<string>(type: "text", nullable: false),
                    Bairro = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    TipoEndereco = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Placa = table.Column<string>(type: "text", nullable: false),
                    Chassi = table.Column<string>(type: "text", nullable: false),
                    Marca = table.Column<string>(type: "text", nullable: false),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Cor = table.Column<string>(type: "text", nullable: false),
                    Ano = table.Column<int>(type: "integer", nullable: false),
                    Motor = table.Column<string>(type: "text", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orcamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Vendedor = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CupomDesconto = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ValorDesconto = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ValorFrete = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: false),
                    ObservacaoInterna = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orcamentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orcamentos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cotacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrcamentoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cotacoes_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemAvulsoOrcamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FabricanteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Sku = table.Column<string>(type: "text", nullable: false),
                    Fabricante = table.Column<string>(type: "text", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    OrcamentoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAvulsoOrcamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemAvulsoOrcamentos_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrcamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    FabricanteId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrcamentoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Sku = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Fabricante = table.Column<string>(type: "text", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrcamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOrcamentos_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemCotacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CotacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Sku = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    TipoProduto = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCotacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCotacoes_Cotacoes_CotacaoId",
                        column: x => x.CotacaoId,
                        principalTable: "Cotacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CodigoEquivalentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Sku = table.Column<string>(type: "text", nullable: false),
                    FabricanteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fabricante = table.Column<string>(type: "text", nullable: false),
                    TipoProdutoEquivalente = table.Column<int>(type: "integer", nullable: false),
                    ItemCotacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoEquivalentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodigoEquivalentes_ItemCotacoes_ItemCotacaoId",
                        column: x => x.ItemCotacaoId,
                        principalTable: "ItemCotacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrecoItemCotacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fornecedor = table.Column<string>(type: "text", nullable: false),
                    FabricanteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fabricante = table.Column<string>(type: "text", nullable: false),
                    Sku = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    ValorCusto = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PrazoExpedicao = table.Column<int>(type: "integer", nullable: false),
                    ItemCotacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecoItemCotacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrecoItemCotacoes_ItemCotacoes_ItemCotacaoId",
                        column: x => x.ItemCotacaoId,
                        principalTable: "ItemCotacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodigoEquivalentes_ItemCotacaoId",
                table: "CodigoEquivalentes",
                column: "ItemCotacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotacoes_OrcamentoId",
                table: "Cotacoes",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteId",
                table: "Endereco",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemAvulsoOrcamentos_OrcamentoId",
                table: "ItemAvulsoOrcamentos",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCotacoes_CotacaoId",
                table: "ItemCotacoes",
                column: "CotacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrcamentos_OrcamentoId",
                table: "ItemOrcamentos",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_ClienteId",
                table: "Orcamentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_VeiculoId",
                table: "Orcamentos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecoItemCotacoes_ItemCotacaoId",
                table: "PrecoItemCotacoes",
                column: "ItemCotacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ClienteId",
                table: "Veiculos",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodigoEquivalentes");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "ItemAvulsoOrcamentos");

            migrationBuilder.DropTable(
                name: "ItemOrcamentos");

            migrationBuilder.DropTable(
                name: "PrecoItemCotacoes");

            migrationBuilder.DropTable(
                name: "ItemCotacoes");

            migrationBuilder.DropTable(
                name: "Cotacoes");

            migrationBuilder.DropTable(
                name: "Orcamentos");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
