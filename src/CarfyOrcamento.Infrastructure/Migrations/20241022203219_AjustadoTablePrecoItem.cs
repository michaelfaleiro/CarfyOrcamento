using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarfyOrcamento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustadoTablePrecoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "PrecoItemCotacoes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "PrecoItemCotacoes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "PrecoItemCotacoes");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "PrecoItemCotacoes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
