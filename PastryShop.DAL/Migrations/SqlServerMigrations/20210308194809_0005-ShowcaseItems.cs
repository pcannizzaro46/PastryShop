using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PastryShop.DAL.Migrations.SqlServerMigrations
{
    public partial class _0005ShowcaseItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShowcaseItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShowcaseItems_DessertId",
                table: "ShowcaseItems",
                column: "DessertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowcaseItems");
        }
    }
}
