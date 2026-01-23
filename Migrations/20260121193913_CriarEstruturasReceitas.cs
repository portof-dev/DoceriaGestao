using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoceriaGestao.Migrations
{
    /// <inheritdoc />
    public partial class CriarEstruturasReceitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeReceita = table.Column<string>(type: "TEXT", nullable: true),
                    Rendimento = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceitaIngredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReceitaId = table.Column<int>(type: "INTEGER", nullable: true),
                    InsumoId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantidadeUtilizada = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaIngredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceitaIngredientes_Insumos_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceitaIngredientes_Receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receitas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaIngredientes_InsumoId",
                table: "ReceitaIngredientes",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaIngredientes_ReceitaId",
                table: "ReceitaIngredientes",
                column: "ReceitaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceitaIngredientes");

            migrationBuilder.DropTable(
                name: "Receitas");
        }
    }
}
