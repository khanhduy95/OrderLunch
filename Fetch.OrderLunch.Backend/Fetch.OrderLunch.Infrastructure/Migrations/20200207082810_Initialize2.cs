using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations
{
    public partial class Initialize2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OrderItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "OrderItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OrderItems",
                nullable: false,
                defaultValue: false);
        }
    }
}
