using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations
{
    public partial class Initialize1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }
    }
}
