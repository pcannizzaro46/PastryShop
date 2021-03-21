using Microsoft.EntityFrameworkCore.Migrations;

namespace PastryShop.DAL.Migrations.SqlServerMigrations
{
    public partial class _004MigrationConstrains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Ingredients_Name",
                table: "Ingredients",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Desserts_Name",
                table: "Desserts",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Ingredients_Name",
                table: "Ingredients");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Desserts_Name",
                table: "Desserts");
        }
    }
}
