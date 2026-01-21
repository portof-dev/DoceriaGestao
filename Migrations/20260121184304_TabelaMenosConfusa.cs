using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoceriaGestao.Migrations
{
    /// <inheritdoc />
    public partial class TabelaMenosConfusa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorMedida",
                table: "Insumos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorMedida",
                table: "Insumos",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
