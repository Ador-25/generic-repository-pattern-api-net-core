using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace generic_repository_pattern.Migrations
{
    public partial class foreignkeynull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "ShopId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
