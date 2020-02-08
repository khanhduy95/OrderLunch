using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations
{
    public partial class RepairBasketEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "basketItems");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "basketItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "basketItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "basketItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Baskets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "Baskets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Baskets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Baskets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "basketItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "basketItems",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "basketItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "basketItems",
                nullable: false,
                defaultValue: false);
        }
    }
}
