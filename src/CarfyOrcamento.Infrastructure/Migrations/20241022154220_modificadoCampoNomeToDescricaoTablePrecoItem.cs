using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarfyOrcamento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modificadoCampoNomeToDescricaoTablePrecoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "PrecoItemCotacoes",
                newName: "Descricao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "PrecoItemCotacoes",
                newName: "Nome");
        }
    }
}
