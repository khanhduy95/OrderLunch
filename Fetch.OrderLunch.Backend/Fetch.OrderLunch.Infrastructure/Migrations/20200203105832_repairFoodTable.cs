using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations
{
    public partial class repairFoodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Menu_MenuId1",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_MenuId1",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "MenuId1",
                table: "Foods");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuId1",
                table: "Foods",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_MenuId1",
                table: "Foods",
                column: "MenuId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Menu_MenuId1",
                table: "Foods",
                column: "MenuId1",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
