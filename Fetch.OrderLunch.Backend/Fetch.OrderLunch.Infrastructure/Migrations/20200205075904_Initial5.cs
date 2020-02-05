using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodDailyMenu",
                table: "FoodDailyMenu");

            migrationBuilder.DropIndex(
                name: "IX_FoodDailyMenu_FoodId",
                table: "FoodDailyMenu");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FoodDailyMenu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodDailyMenu",
                table: "FoodDailyMenu",
                columns: new[] { "FoodId", "DailyMenuId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodDailyMenu",
                table: "FoodDailyMenu");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FoodDailyMenu",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodDailyMenu",
                table: "FoodDailyMenu",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDailyMenu_FoodId",
                table: "FoodDailyMenu",
                column: "FoodId");
        }
    }
}
