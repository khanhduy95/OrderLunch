using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations
{
    public partial class AddListFoodToMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DailyMenuId",
                table: "Foods",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId1",
                table: "Foods",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_DailyMenuId",
                table: "Foods",
                column: "DailyMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_MenuId1",
                table: "Foods",
                column: "MenuId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_DailyMenu_DailyMenuId",
                table: "Foods",
                column: "DailyMenuId",
                principalTable: "DailyMenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Menu_MenuId1",
                table: "Foods",
                column: "MenuId1",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_DailyMenu_DailyMenuId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Menu_MenuId1",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_DailyMenuId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_MenuId1",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "DailyMenuId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "MenuId1",
                table: "Foods");
        }
    }
}
