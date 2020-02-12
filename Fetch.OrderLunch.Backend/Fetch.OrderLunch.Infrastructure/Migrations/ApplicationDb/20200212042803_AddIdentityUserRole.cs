using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations.ApplicationDb
{
    public partial class AddIdentityUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "017b2cdc-4bf2-11ea-b77f-2e728ce88125", "17eb914a-4c20-11ea-b77f-2e728ce88125" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a89e59c-4c20-11ea-b77f-2e728ce88125",
                column: "ConcurrencyStamp",
                value: "b9606f05-ecb1-4fee-90e6-2c862465a16b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17eb914a-4c20-11ea-b77f-2e728ce88125",
                column: "ConcurrencyStamp",
                value: "877131a5-09d8-40c4-b7b5-4e1a71d3f428");

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Role Edit", "true", "017b2cdc-4bf2-11ea-b77f-2e728ce88125" },
                    { 2, "Delete Edit", "true", "017b2cdc-4bf2-11ea-b77f-2e728ce88125" },
                    { 3, "Create Edit", "true", "017b2cdc-4bf2-11ea-b77f-2e728ce88125" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "017b2cdc-4bf2-11ea-b77f-2e728ce88125",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "50ae289f-a3c9-4f1d-951f-1eb06532bd0c", "AQAAAAEAACcQAAAAEHYQLhUgSzyE0LdqYSTQPmGtsNk0PiA7fb49i2YeNVf+XFs3ChDJrn/OOR2aeDsflw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a89e59c-4c20-11ea-b77f-2e728ce88125",
                column: "ConcurrencyStamp",
                value: "0d3b65ae-b62a-4a59-b15b-bb8abe1b8ead");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17eb914a-4c20-11ea-b77f-2e728ce88125",
                column: "ConcurrencyStamp",
                value: "ccd39228-d13a-44a2-86a6-bb011fc3cd56");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "017b2cdc-4bf2-11ea-b77f-2e728ce88125", "17eb914a-4c20-11ea-b77f-2e728ce88125" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "017b2cdc-4bf2-11ea-b77f-2e728ce88125",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a4bc7410-e92f-4954-ac4c-554424831d76", "AQAAAAEAACcQAAAAEP2qLeW3IubmFOKGhwvw2wDQpLMdtHkQn9Swyg0m0YXxPEPsw1fTBUEZHrLXevil7w==" });
        }
    }
}
