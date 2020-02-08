using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations
{
    public partial class RepairBuyerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Buyers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Buyers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "Buyers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Buyers",
                nullable: false,
                defaultValue: false);
        }
    }
}
