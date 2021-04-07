using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Persistence.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CAR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VinCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CAR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_CUSTOMER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CUSTOMER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_ORDER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ORDER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ORDER_TB_CAR_IdCar",
                        column: x => x.IdCar,
                        principalTable: "TB_CAR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_ORDER_TB_CUSTOMER_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "TB_CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_EXTRA_ORDER_ITEM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EXTRA_ORDER_ITEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_EXTRA_ORDER_ITEM_TB_ORDER_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "TB_ORDER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_EXTRA_ORDER_ITEM_IdOrder",
                table: "TB_EXTRA_ORDER_ITEM",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORDER_IdCar",
                table: "TB_ORDER",
                column: "IdCar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORDER_IdCustomer",
                table: "TB_ORDER",
                column: "IdCustomer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_EXTRA_ORDER_ITEM");

            migrationBuilder.DropTable(
                name: "TB_ORDER");

            migrationBuilder.DropTable(
                name: "TB_CAR");

            migrationBuilder.DropTable(
                name: "TB_CUSTOMER");
        }
    }
}
