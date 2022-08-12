using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductFeederCoreLib.Migrations
{
    public partial class updateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Suppliers_SupplierId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Brands_SupplierId",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Products",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                newName: "IX_Products_Brands");

            migrationBuilder.AddColumn<int>(
                name: "Suppliers",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Suppliers",
                table: "Brands",
                column: "Suppliers");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Suppliers_Suppliers",
                table: "Brands",
                column: "Suppliers",
                principalTable: "Suppliers",
                principalColumn: "Id");

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
                name: "FK_Brands_Suppliers_Suppliers",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_Brands",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Brands_Suppliers",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Suppliers",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "Brands",
                table: "Products",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Brands",
                table: "Products",
                newName: "IX_Products_BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_SupplierId",
                table: "Brands",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Suppliers_SupplierId",
                table: "Brands",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }
    }
}
