using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Collaborative.Infra.Migrations
{
    public partial class OrderProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_OrderId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Order");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 905, DateTimeKind.Local).AddTicks(7693),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(6541));

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Order",
                type: "DECIMAL(5,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(5,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ordered",
                table: "Order",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 905, DateTimeKind.Local).AddTicks(1741),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Open",
                table: "FinancialAccount",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 905, DateTimeKind.Local).AddTicks(885),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(2818));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FinancialAccount",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborator",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 904, DateTimeKind.Local).AddTicks(9917),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborative",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 904, DateTimeKind.Local).AddTicks(8923),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 1),
                    Value = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FinancialAccount");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(6541),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 905, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Order",
                type: "DECIMAL(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(5,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ordered",
                table: "Order",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(3630),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 905, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Open",
                table: "FinancialAccount",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(2818),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 905, DateTimeKind.Local).AddTicks(885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborator",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(1709),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 904, DateTimeKind.Local).AddTicks(9917));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Collaborative",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(775),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2020, 9, 12, 9, 21, 27, 904, DateTimeKind.Local).AddTicks(8923));

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderId",
                table: "Product",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "Order",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Order_OrderId",
                table: "Product",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
