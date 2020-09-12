using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Collaborative.Infra.Migrations
{
    public partial class RefatoringStockClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Stock");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stock",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 170, DateTimeKind.Local).AddTicks(6798),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 905, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Product",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ordered",
                table: "Order",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 170, DateTimeKind.Local).AddTicks(657),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 905, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Open",
                table: "FinancialAccount",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(9787),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 905, DateTimeKind.Local).AddTicks(885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborator",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(8760),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 904, DateTimeKind.Local).AddTicks(9917));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborative",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(7486),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 904, DateTimeKind.Local).AddTicks(8923));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Stock",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 905, DateTimeKind.Local).AddTicks(7693),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 170, DateTimeKind.Local).AddTicks(6798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ordered",
                table: "Order",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 905, DateTimeKind.Local).AddTicks(1741),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 170, DateTimeKind.Local).AddTicks(657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Open",
                table: "FinancialAccount",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 905, DateTimeKind.Local).AddTicks(885),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborator",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 904, DateTimeKind.Local).AddTicks(9917),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(8760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborative",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 904, DateTimeKind.Local).AddTicks(8923),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 10, 0, 58, 169, DateTimeKind.Local).AddTicks(7486));
        }
    }
}
