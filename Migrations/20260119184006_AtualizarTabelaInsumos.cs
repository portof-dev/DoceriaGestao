using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoceriaGestao.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarTabelaInsumos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecoProduto",
                table: "Insumos",
                newName: "PrecoCompra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecoCompra",
                table: "Insumos",
                newName: "PrecoProduto");
        }
    }
}
