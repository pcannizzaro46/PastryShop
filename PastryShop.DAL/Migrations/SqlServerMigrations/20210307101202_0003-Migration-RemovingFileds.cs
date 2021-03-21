using Microsoft.EntityFrameworkCore.Migrations;

namespace PastryShop.DAL.Migrations.SqlServerMigrations
{
    public partial class _0003MigrationRemovingFileds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dummyfield",
                table: "Desserts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dummyfield",
                table: "Desserts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
