using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations.ApplicationDb
{
    public partial class Initialize2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "017b2cdc-4bf2-11ea-b77f-2e728ce88125", "017b520c-4bf2-11ea-b77f-2e728ce88125" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "017b520c-4bf2-11ea-b77f-2e728ce88125");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17eb914a-4c20-11ea-b77f-2e728ce88125", "ccd39228-d13a-44a2-86a6-bb011fc3cd56", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a89e59c-4c20-11ea-b77f-2e728ce88125", "0d3b65ae-b62a-4a59-b15b-bb8abe1b8ead", "Member", "Member" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "017b2cdc-4bf2-11ea-b77f-2e728ce88125",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a4bc7410-e92f-4954-ac4c-554424831d76", "AQAAAAEAACcQAAAAEP2qLeW3IubmFOKGhwvw2wDQpLMdtHkQn9Swyg0m0YXxPEPsw1fTBUEZHrLXevil7w==" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "017b2cdc-4bf2-11ea-b77f-2e728ce88125", "17eb914a-4c20-11ea-b77f-2e728ce88125" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a89e59c-4c20-11ea-b77f-2e728ce88125");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "017b2cdc-4bf2-11ea-b77f-2e728ce88125", "17eb914a-4c20-11ea-b77f-2e728ce88125" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17eb914a-4c20-11ea-b77f-2e728ce88125");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "017b520c-4bf2-11ea-b77f-2e728ce88125", "d4855025-9f73-4c47-997a-3814eafd0f7f", "Admin Role", "Admin Role" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "017b2cdc-4bf2-11ea-b77f-2e728ce88125",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c4769504-614c-4ca3-ab55-a0a86e59978a", "AQAAAAEAACcQAAAAEMhQpkAJRyAHOx81ld/xevhvhwsbA7+yCr6NVDiY+PpetFaRFUu8rCieYQYbjkzBcQ==" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "017b2cdc-4bf2-11ea-b77f-2e728ce88125", "017b520c-4bf2-11ea-b77f-2e728ce88125" });
        }
    }
}
