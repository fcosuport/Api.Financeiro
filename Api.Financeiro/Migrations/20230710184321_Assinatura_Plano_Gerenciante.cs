using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Financeiro.Migrations
{
    /// <inheritdoc />
    public partial class Assinatura_Plano_Gerenciante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodProdGn",
                table: "Produtos",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodAssinatura",
                table: "Assinaturas",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtPrimeiraParcela",
                table: "Assinaturas",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodProdGn",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CodAssinatura",
                table: "Assinaturas");

            migrationBuilder.DropColumn(
                name: "DtPrimeiraParcela",
                table: "Assinaturas");
        }
    }
}
