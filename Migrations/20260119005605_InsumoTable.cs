using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoceriaGestao.Migrations
{
    /// <inheritdoc />
    public partial class InsumoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDoProduto = table.Column<string>(type: "TEXT", nullable: true),
                    PrecoProduto = table.Column<decimal>(type: "TEXT", nullable: false),
                    QuantidadeCompra = table.Column<decimal>(type: "TEXT", nullable: false),
                    Unidade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insumos");
        }
    }
}
