using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductFeederCoreLib.Migrations
{
    public partial class setNullProdutFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UPC",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EAN",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.Sql("UPDATE dbo.Products SET ConditionId=1 where Id>0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UPC",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EAN",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTimeStamp",
                value: new DateTime(2022, 8, 25, 16, 56, 10, 752, DateTimeKind.Local).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTimeStamp",
                value: new DateTime(2022, 8, 25, 16, 56, 10, 752, DateTimeKind.Local).AddTicks(4761));
        }
    }
}
