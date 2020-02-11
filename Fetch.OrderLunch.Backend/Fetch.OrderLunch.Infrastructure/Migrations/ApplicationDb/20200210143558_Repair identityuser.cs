using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations.ApplicationDb
{
    public partial class Repairidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "017b520c-4bf2-11ea-b77f-2e728ce88125",
                column: "ConcurrencyStamp",
                value: "47e4b4d6-8e5d-468c-a750-511897ab38b7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "017b2cdc-4bf2-11ea-b77f-2e728ce88125",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f4f9d3dd-b717-416c-8d4a-4af188f8b8c4", "Admin@123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "017b520c-4bf2-11ea-b77f-2e728ce88125",
                column: "ConcurrencyStamp",
                value: "7043f7ee-c9a9-4271-81d3-6b415bc069d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "017b2cdc-4bf2-11ea-b77f-2e728ce88125",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2fd52367-d5f7-4b27-ba07-b2d80b8b0a35", "Admin " });
        }
    }
}
