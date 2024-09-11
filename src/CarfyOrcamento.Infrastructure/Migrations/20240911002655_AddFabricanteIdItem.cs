using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarfyOrcamento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFabricanteIdItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "ItemOrcamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FabricanteId",
                table: "ItemOrcamentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "ItemAvulsoOrcamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FabricanteId",
                table: "ItemAvulsoOrcamentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "ItemOrcamentos");

            migrationBuilder.DropColumn(
                name: "FabricanteId",
                table: "ItemOrcamentos");

            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "ItemAvulsoOrcamentos");

            migrationBuilder.DropColumn(
                name: "FabricanteId",
                table: "ItemAvulsoOrcamentos");
        }
    }
}
