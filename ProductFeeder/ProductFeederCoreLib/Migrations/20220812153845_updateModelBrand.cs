using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductFeederCoreLib.Migrations
{
    public partial class updateModelBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Suppliers_Suppliers",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_Suppliers",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Suppliers",
                table: "Brands");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Suppliers_SupplierId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_SupplierId",
                table: "Brands");

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
        }
    }
}
