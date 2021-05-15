using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterChef.Infrastructure.Data.Migrations
{
    public partial class CategoriaReceitaUmPraUm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Receitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_CategoriaId",
                table: "Receitas",
                column: "CategoriaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Categorias_CategoriaId",
                table: "Receitas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Categorias_CategoriaId",
                table: "Receitas");

            migrationBuilder.DropIndex(
                name: "IX_Receitas_CategoriaId",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Receitas");
        }
    }
}
