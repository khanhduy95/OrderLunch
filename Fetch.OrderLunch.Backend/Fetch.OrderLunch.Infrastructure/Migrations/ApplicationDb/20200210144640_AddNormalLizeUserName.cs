using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations.ApplicationDb
{
    public partial class AddNormalLizeUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "9d1347d3-8b7c-4fc7-a758-3265c4236903", "ADMIN", "AQAAAAEAACcQAAAAEB2hWPk9okBCH+b6qc2ETMys0NH6R+lO7WHd03tv4Q43ow+kRkjOb+OI/Px5KvgJZQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "2bc6767c-4798-4e37-8906-2e0fa5054029", null, "AQAAAAEAACcQAAAAEFkyvqRiKOugwtuuteT9ltOFIlt7UlNB7tUC/nPRdmAW2OwoympoqC3Eumw6cDDnpw==" });
        }
    }
}
