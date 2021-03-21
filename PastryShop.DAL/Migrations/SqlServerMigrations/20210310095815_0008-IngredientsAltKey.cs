using Microsoft.EntityFrameworkCore.Migrations;

namespace PastryShop.DAL.Migrations.SqlServerMigrations
{
    public partial class _0008IngredientsAltKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Ingredients_Name",
                table: "Ingredients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Ingredients_Name",
                table: "Ingredients",
                column: "Name");
        }
    }
}
