using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations.ApplicationDb
{
    public partial class AddBasketIdToBaketItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "017b520c-4bf2-11ea-b77f-2e728ce88125",
                column: "ConcurrencyStamp",
                value: "d4855025-9f73-4c47-997a-3814eafd0f7f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "017b2cdc-4bf2-11ea-b77f-2e728ce88125",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c4769504-614c-4ca3-ab55-a0a86e59978a", "AQAAAAEAACcQAAAAEMhQpkAJRyAHOx81ld/xevhvhwsbA7+yCr6NVDiY+PpetFaRFUu8rCieYQYbjkzBcQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "017b520c-4bf2-11ea-b77f-2e728ce88125",
                column: "ConcurrencyStamp",
                value: "360134dd-2496-4c80-809e-4cbcd1b013ae");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "017b2cdc-4bf2-11ea-b77f-2e728ce88125",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9d1347d3-8b7c-4fc7-a758-3265c4236903", "AQAAAAEAACcQAAAAEB2hWPk9okBCH+b6qc2ETMys0NH6R+lO7WHd03tv4Q43ow+kRkjOb+OI/Px5KvgJZQ==" });
        }
    }
}
