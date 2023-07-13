using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Financeiro.Migrations
{
    /// <inheritdoc />
    public partial class NomeWhats_Assinatura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeWhats",
                table: "Assinaturas",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeWhats",
                table: "Assinaturas");
        }
    }
}
