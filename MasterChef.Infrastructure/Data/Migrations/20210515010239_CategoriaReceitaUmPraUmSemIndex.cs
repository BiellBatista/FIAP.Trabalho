using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterChef.Infrastructure.Data.Migrations
{
    public partial class CategoriaReceitaUmPraUmSemIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
               name: "IX_Receitas_CategoriaId",
               table: "Receitas");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_CategoriaId",
                table: "Receitas",
                column: "CategoriaId",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}