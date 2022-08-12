using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductFeederCoreLib.Migrations
{
    public partial class updateModelProductsAddForeingKeyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_Brands",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Brands",
                table: "Products",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Brands",
                table: "Products",
                newName: "IX_Products_BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Products",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                newName: "IX_Products_Brands");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_Brands",
                table: "Products",
                column: "Brands",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
