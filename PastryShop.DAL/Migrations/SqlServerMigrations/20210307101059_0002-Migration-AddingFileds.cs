using Microsoft.EntityFrameworkCore.Migrations;

namespace PastryShop.DAL.Migrations.SqlServerMigrations
{
    public partial class _0002MigrationAddingFileds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dummyfield",
                table: "Desserts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dummyfield",
                table: "Desserts");
        }
    }
}
