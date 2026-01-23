using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoceriaGestao.Migrations
{
    /// <inheritdoc />
    public partial class AjusteEstruturaReceitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaIngredientes_Receitas_ReceitaId",
                table: "ReceitaIngredientes");

            migrationBuilder.AlterColumn<int>(
                name: "ReceitaId",
                table: "ReceitaIngredientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaIngredientes_Receitas_ReceitaId",
                table: "ReceitaIngredientes",
                column: "ReceitaId",
                principalTable: "Receitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaIngredientes_Receitas_ReceitaId",
                table: "ReceitaIngredientes");

            migrationBuilder.AlterColumn<int>(
                name: "ReceitaId",
                table: "ReceitaIngredientes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaIngredientes_Receitas_ReceitaId",
                table: "ReceitaIngredientes",
                column: "ReceitaId",
                principalTable: "Receitas",
                principalColumn: "Id");
        }
    }
}
