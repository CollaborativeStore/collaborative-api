using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Collaborative.Infra.Migrations
{
    public partial class ReworkForeingKeyStockCollab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborative_Stock_StockId",
                table: "Collaborative");

            migrationBuilder.DropIndex(
                name: "IX_Collaborative_StockId",
                table: "Collaborative");

            migrationBuilder.AddColumn<int>(
                name: "CollaborativeId",
                table: "Stock",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 27, DateTimeKind.Local).AddTicks(8938),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 301, DateTimeKind.Local).AddTicks(827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ordered",
                table: "Order",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(8883),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Open",
                table: "FinancialAccount",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(7994),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(2630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborator",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(6839),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(1410));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborative",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(5806),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(391));

            migrationBuilder.CreateIndex(
                name: "IX_Stock_CollaborativeId",
                table: "Stock",
                column: "CollaborativeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Collaborative_CollaborativeId",
                table: "Stock",
                column: "CollaborativeId",
                principalTable: "Collaborative",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Collaborative_CollaborativeId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_CollaborativeId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "CollaborativeId",
                table: "Stock");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 301, DateTimeKind.Local).AddTicks(827),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 27, DateTimeKind.Local).AddTicks(8938));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ordered",
                table: "Order",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(3565),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(8883));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Open",
                table: "FinancialAccount",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(2630),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborator",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(1410),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborative",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 14, 17, 36, 5, 300, DateTimeKind.Local).AddTicks(391),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 14, 19, 4, 33, 26, DateTimeKind.Local).AddTicks(5806));

            migrationBuilder.CreateIndex(
                name: "IX_Collaborative_StockId",
                table: "Collaborative",
                column: "StockId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborative_Stock_StockId",
                table: "Collaborative",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
