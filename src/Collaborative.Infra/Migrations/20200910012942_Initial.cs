using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Collaborative.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collaborative",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Phone2 = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: true),
                    CPF = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: true),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: true),
                    Mail = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(775)),
                    ClosingDate = table.Column<DateTime>(nullable: true),
                    StockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborative", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collaborative_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collaborator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Phone2 = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: true),
                    CPF = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: true),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: true),
                    Mail = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(1709)),
                    ClosingDate = table.Column<DateTime>(nullable: true),
                    CollaborativeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collaborator_Collaborative_CollaborativeId",
                        column: x => x.CollaborativeId,
                        principalTable: "Collaborative",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinancialAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Open = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(2818)),
                    Close = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    CollaborativeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialAccount_Collaborative_CollaborativeId",
                        column: x => x.CollaborativeId,
                        principalTable: "Collaborative",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ordered = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(3630)),
                    Status = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    CollaborativeId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Collaborative_CollaborativeId",
                        column: x => x.CollaborativeId,
                        principalTable: "Collaborative",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Paid = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    Total = table.Column<decimal>(type: "DECIMAL(6,2)", nullable: false),
                    Details = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    FinancialAccountId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_FinancialAccount_FinancialAccountId",
                        column: x => x.FinancialAccountId,
                        principalTable: "FinancialAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2020, 9, 9, 22, 29, 42, 532, DateTimeKind.Local).AddTicks(6541)),
                    DeletionDate = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    UnityPrice = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    CollaboratorId = table.Column<int>(nullable: false),
                    StockId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborative_StockId",
                table: "Collaborative",
                column: "StockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_CollaborativeId",
                table: "Collaborator",
                column: "CollaborativeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialAccount_CollaborativeId",
                table: "FinancialAccount",
                column: "CollaborativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CollaborativeId",
                table: "Order",
                column: "CollaborativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_FinancialAccountId",
                table: "Payment",
                column: "FinancialAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderId",
                table: "Payment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CollaboratorId",
                table: "Product",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderId",
                table: "Product",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StockId",
                table: "Product",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "Order",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborative_Stock_StockId",
                table: "Collaborative");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Stock_StockId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Collaborator_Collaborative_CollaborativeId",
                table: "Collaborator");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Collaborative_CollaborativeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "FinancialAccount");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Collaborative");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Collaborator");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
