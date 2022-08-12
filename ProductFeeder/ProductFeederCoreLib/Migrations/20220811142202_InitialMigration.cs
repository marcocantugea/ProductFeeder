using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductFeederCoreLib.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RazonSocial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreationDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "current_timestamp"),
                    DeletionDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "current_timestamp"),
                    DeletionDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sku = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    idBrand = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    CreationDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "current_timestamp"),
                    DeletionDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListPrice = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartPriceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndPriceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "current_timestamp"),
                    DeletionDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_SupplierId",
                table: "Brands",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ProductId",
                table: "Prices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
