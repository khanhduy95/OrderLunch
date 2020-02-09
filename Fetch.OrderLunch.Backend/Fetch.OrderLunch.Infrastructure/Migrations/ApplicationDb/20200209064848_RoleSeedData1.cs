using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations.ApplicationDb
{
    public partial class RoleSeedData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6d5f3c0-144d-4e4f-9ca0-3eb62435efde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8678669-bb3a-40f3-80a0-46aecaf64106");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8678669-bb3a-40f3-80a0-46aecaf64106", "92aefd66-cb05-4e7e-a39f-c763ca5ee0ee", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6d5f3c0-144d-4e4f-9ca0-3eb62435efde", "c3f5044b-0850-44b1-b07b-c359da82e726", "Member", "member" });
        }
    }
}
