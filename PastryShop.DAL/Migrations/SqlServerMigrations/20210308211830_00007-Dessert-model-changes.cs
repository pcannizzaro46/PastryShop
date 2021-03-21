using Microsoft.EntityFrameworkCore.Migrations;

namespace PastryShop.DAL.Migrations.SqlServerMigrations
{
    public partial class _00007Dessertmodelchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Desserts_DessertId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowcaseItems_Desserts_DessertId",
                table: "ShowcaseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Desserts",
                table: "Desserts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Desserts");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DessertId",
                table: "Desserts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Desserts",
                table: "Desserts",
                column: "DessertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Desserts_DessertId",
                table: "Ingredients",
                column: "DessertId",
                principalTable: "Desserts",
                principalColumn: "DessertId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowcaseItems_Desserts_DessertId",
                table: "ShowcaseItems",
                column: "DessertId",
                principalTable: "Desserts",
                principalColumn: "DessertId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Desserts_DessertId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowcaseItems_Desserts_DessertId",
                table: "ShowcaseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Desserts",
                table: "Desserts");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DessertId",
                table: "Desserts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Desserts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Desserts",
                table: "Desserts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Desserts_DessertId",
                table: "Ingredients",
                column: "DessertId",
                principalTable: "Desserts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowcaseItems_Desserts_DessertId",
                table: "ShowcaseItems",
                column: "DessertId",
                principalTable: "Desserts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
