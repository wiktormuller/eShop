using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.Infrastructure.Migrations
{
    public partial class RepairRelationships2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Orders_OrderId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_OrderId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OrderId",
                table: "Customers",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Orders_OrderId",
                table: "Customers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Orders_OrderId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_OrderId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OrderId",
                table: "Customers",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Orders_OrderId",
                table: "Customers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
