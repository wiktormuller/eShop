using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.Infrastructure.Migrations
{
    public partial class AddTotalPriceInShoppingCartEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ShoppingCarts",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "ShoppingCarts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
