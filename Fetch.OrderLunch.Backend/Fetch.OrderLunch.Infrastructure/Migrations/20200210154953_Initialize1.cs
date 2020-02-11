using Microsoft.EntityFrameworkCore.Migrations;

namespace Fetch.OrderLunch.Infrastructure.Migrations
{
    public partial class Initialize1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_basketItems_Baskets_BasketId",
                table: "basketItems");

            migrationBuilder.AddForeignKey(
                name: "FK_basketItems_Baskets_BasketId",
                table: "basketItems",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_basketItems_Baskets_BasketId",
                table: "basketItems");

            migrationBuilder.AddForeignKey(
                name: "FK_basketItems_Baskets_BasketId",
                table: "basketItems",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
