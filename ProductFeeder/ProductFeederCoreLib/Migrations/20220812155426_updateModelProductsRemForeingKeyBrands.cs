using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductFeederCoreLib.Migrations
{
    public partial class updateModelProductsRemForeingKeyBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_Brands",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Brands",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_Brands",
                table: "Products",
                column: "Brands",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_Brands",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Brands",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_Brands",
                table: "Products",
                column: "Brands",
                principalTable: "Brands",
                principalColumn: "Id");
        }
    }
}
