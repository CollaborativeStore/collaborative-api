using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Collaborative.Infra.Migrations
{
    public partial class RefactoringCollaborativeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Collaborative");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 15, 16, 21, 33, 487, DateTimeKind.Local).AddTicks(6241),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 27, DateTimeKind.Local).AddTicks(8938));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ordered",
                table: "Order",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 15, 16, 21, 33, 487, DateTimeKind.Local).AddTicks(341),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(8883));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Open",
                table: "FinancialAccount",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 15, 16, 21, 33, 486, DateTimeKind.Local).AddTicks(9350),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborator",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 15, 16, 21, 33, 486, DateTimeKind.Local).AddTicks(8164),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborative",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 15, 16, 21, 33, 486, DateTimeKind.Local).AddTicks(7109),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(5806));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 27, DateTimeKind.Local).AddTicks(8938),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 15, 16, 21, 33, 487, DateTimeKind.Local).AddTicks(6241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ordered",
                table: "Order",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(8883),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 15, 16, 21, 33, 487, DateTimeKind.Local).AddTicks(341));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Open",
                table: "FinancialAccount",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(7994),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 15, 16, 21, 33, 486, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborator",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(6839),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 15, 16, 21, 33, 486, DateTimeKind.Local).AddTicks(8164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborative",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(5806),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 15, 16, 21, 33, 486, DateTimeKind.Local).AddTicks(7109));

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Collaborative",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
