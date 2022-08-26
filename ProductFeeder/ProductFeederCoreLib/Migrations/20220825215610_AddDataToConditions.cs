using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductFeederCoreLib.Migrations
{
    public partial class AddDataToConditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "conditionDescription",
                table: "Conditions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTimeStamp",
                table: "Conditions",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "current_timestamp",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "Id", "Active", "CreationDateTimeStamp", "DeletionDateTimeStamp", "conditionDescription" },
                values: new object[] { 1, true, new DateTime(2022, 8, 25, 16, 56, 10, 752, DateTimeKind.Local).AddTicks(4722), null, "NEW" });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "Id", "Active", "CreationDateTimeStamp", "DeletionDateTimeStamp", "conditionDescription" },
                values: new object[] { 2, true, new DateTime(2022, 8, 25, 16, 56, 10, 752, DateTimeKind.Local).AddTicks(4761), null, "REFURBISH" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "conditionDescription",
                table: "Conditions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTimeStamp",
                table: "Conditions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "current_timestamp");
        }
    }
}
