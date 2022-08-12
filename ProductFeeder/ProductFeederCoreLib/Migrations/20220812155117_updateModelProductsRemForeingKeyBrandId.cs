using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductFeederCoreLib.Migrations
{
    public partial class updateModelProductsRemForeingKeyBrandId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Brands",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Brands",
                table: "Products",
                column: "Brands");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_Brands",
                table: "Products",
                column: "Brands",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_Brands",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Brands",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Brands",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
