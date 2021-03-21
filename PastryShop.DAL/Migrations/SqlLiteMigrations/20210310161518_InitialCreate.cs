using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PastryShop.DAL.Migrations.SqlLiteMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desserts",
                columns: table => new
                {
                    DessertId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    ImageFullPath = table.Column<string>(nullable: false),
                    UserCreate = table.Column<string>(maxLength: 30, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desserts", x => x.DessertId);
                    table.UniqueConstraint("AK_Desserts_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DessertId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    UM = table.Column<string>(maxLength: 2, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    UserCreate = table.Column<string>(maxLength: 30, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredients_Desserts_DessertId",
                        column: x => x.DessertId,
                        principalTable: "Desserts",
                        principalColumn: "DessertId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowcaseItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DessertId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(maxLength: 30, nullable: false),
                    Enable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowcaseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowcaseItems_Desserts_DessertId",
                        column: x => x.DessertId,
                        principalTable: "Desserts",
                        principalColumn: "DessertId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DessertId",
                table: "Ingredients",
                column: "DessertId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowcaseItems_DessertId",
                table: "ShowcaseItems",
                column: "DessertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "ShowcaseItems");

            migrationBuilder.DropTable(
                name: "Desserts");
        }
    }
}
