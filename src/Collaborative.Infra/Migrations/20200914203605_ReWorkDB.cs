using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Collaborative.Infra.Migrations
{
    public partial class ReWorkDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 301, DateTimeKind.Local).AddTicks(827),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 170, DateTimeKind.Local).AddTicks(6798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ordered",
                table: "Order",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(3565),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 170, DateTimeKind.Local).AddTicks(657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Open",
                table: "FinancialAccount",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(2630),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborator",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(1410),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(8760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborative",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(391),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(7486));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 170, DateTimeKind.Local).AddTicks(6798),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 301, DateTimeKind.Local).AddTicks(827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ordered",
                table: "Order",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 170, DateTimeKind.Local).AddTicks(657),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Open",
                table: "FinancialAccount",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(9787),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(2630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborator",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(8760),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(1410));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborative",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(7486),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(391));
        }
    }
}
