using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations
{
    public partial class RepairDailyMenuTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_DailyMenu_DailyMenuId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_DailyMenuId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "DailyMenuId",
                table: "Foods");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DailyMenuId",
                table: "Foods",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_DailyMenuId",
                table: "Foods",
                column: "DailyMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_DailyMenu_DailyMenuId",
                table: "Foods",
                column: "DailyMenuId",
                principalTable: "DailyMenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
