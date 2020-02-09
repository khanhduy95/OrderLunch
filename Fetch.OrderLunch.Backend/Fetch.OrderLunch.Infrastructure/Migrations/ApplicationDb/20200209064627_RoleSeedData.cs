using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations.ApplicationDb
{
    public partial class RoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28e31e72-2dca-4dad-8cc1-0978843bedda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a05b3a38-da21-4b99-b670-07d0a33b933b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8678669-bb3a-40f3-80a0-46aecaf64106", "92aefd66-cb05-4e7e-a39f-c763ca5ee0ee", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6d5f3c0-144d-4e4f-9ca0-3eb62435efde", "c3f5044b-0850-44b1-b07b-c359da82e726", "Member", "member" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6d5f3c0-144d-4e4f-9ca0-3eb62435efde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8678669-bb3a-40f3-80a0-46aecaf64106");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28e31e72-2dca-4dad-8cc1-0978843bedda", "88b41c26-e49d-4d01-bba5-d6696737158c", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a05b3a38-da21-4b99-b670-07d0a33b933b", "9b9c0eff-d503-4ee1-9548-b6584a4540ea", "Member", "member" });
        }
    }
}
