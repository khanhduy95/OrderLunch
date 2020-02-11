using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations.ApplicationDb
{
    public partial class HashPasswordInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "017b520c-4bf2-11ea-b77f-2e728ce88125",
                column: "ConcurrencyStamp",
                value: "e69e01e1-8a99-4de1-a675-2bb8d8da9c01");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "017b2cdc-4bf2-11ea-b77f-2e728ce88125",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2bc6767c-4798-4e37-8906-2e0fa5054029", "AQAAAAEAACcQAAAAEFkyvqRiKOugwtuuteT9ltOFIlt7UlNB7tUC/nPRdmAW2OwoympoqC3Eumw6cDDnpw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
