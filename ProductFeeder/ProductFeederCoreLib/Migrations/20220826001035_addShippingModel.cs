using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductFeederCoreLib.Migrations
{
    public partial class addShippingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShippingId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Shippings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTimeStamp",
                value: new DateTime(2022, 8, 25, 19, 10, 35, 62, DateTimeKind.Local).AddTicks(2658));

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTimeStamp",
                value: new DateTime(2022, 8, 25, 19, 10, 35, 62, DateTimeKind.Local).AddTicks(2706));

            migrationBuilder.InsertData(
                table: "Shippings",
                columns: new[] { "Id", "Active", "CreationDateTimeStamp", "DeletionDateTimeStamp", "ShippingName" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2022, 8, 25, 19, 10, 35, 62, DateTimeKind.Local).AddTicks(2968), null, "SHIPPING" },
                    { 2, true, new DateTime(2022, 8, 25, 19, 10, 35, 62, DateTimeKind.Local).AddTicks(2977), null, "ONREQUEST" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShippingId",
                table: "Products",
                column: "ShippingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shippings_ShippingId",
                table: "Products",
                column: "ShippingId",
                principalTable: "Shippings",
                principalColumn: "Id");

            migrationBuilder.Sql("UPDATE dbo.Products SET ShippingId=2 where Id>0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shippings_ShippingId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Shippings");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShippingId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShippingId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTimeStamp",
                value: new DateTime(2022, 8, 25, 18, 34, 53, 423, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTimeStamp",
                value: new DateTime(2022, 8, 25, 18, 34, 53, 423, DateTimeKind.Local).AddTicks(3189));
        }
    }
}
