using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoceriaGestao.Migrations
{
    /// <inheritdoc />
    public partial class ImplementoTabelaInsumos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantidadeCompra",
                table: "Insumos",
                newName: "ValorMedida");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeItens",
                table: "Insumos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeItens",
                table: "Insumos");

            migrationBuilder.RenameColumn(
                name: "ValorMedida",
                table: "Insumos",
                newName: "QuantidadeCompra");
        }
    }
}
