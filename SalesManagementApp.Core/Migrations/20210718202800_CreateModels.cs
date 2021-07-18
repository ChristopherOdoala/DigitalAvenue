using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesManagementApp.Core.Migrations
{
    public partial class CreateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Master_Countries",
                columns: table => new
                {
                    rowguid = table.Column<Guid>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_Countries", x => x.rowguid);
                });

            migrationBuilder.CreateTable(
                name: "Master_Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductCategoryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    rowguid = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProductNumber = table.Column<string>(nullable: true),
                    MakeFlag = table.Column<bool>(nullable: false),
                    FinishedGoodsFlag = table.Column<bool>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    SafetyStockLevel = table.Column<short>(nullable: false),
                    ReorderPoint = table.Column<short>(nullable: false),
                    StandardCost = table.Column<decimal>(nullable: false),
                    ListPrice = table.Column<decimal>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    SizeUnitMeasureCode = table.Column<string>(nullable: true),
                    WeightUnitMeasureCode = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    DaysToManufacture = table.Column<int>(nullable: false),
                    ProductLine = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Style = table.Column<string>(nullable: true),
                    ProductSubcategoryID = table.Column<int>(nullable: false),
                    ProductModelID = table.Column<int>(nullable: false),
                    SellStartDate = table.Column<DateTime>(nullable: false),
                    SellEndDate = table.Column<DateTime>(nullable: false),
                    DiscontinuedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.rowguid);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    rowguid = table.Column<Guid>(nullable: false),
                    SalesOrderID = table.Column<int>(nullable: false),
                    SalesOrderDetailID = table.Column<int>(nullable: false),
                    CarrierTrackingNumber = table.Column<string>(nullable: true),
                    OrderQty = table.Column<short>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    SpecialOfferID = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    UnitPriceDiscount = table.Column<decimal>(nullable: false),
                    LineTotal = table.Column<decimal>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.rowguid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Master_Region",
                columns: table => new
                {
                    rowguid = table.Column<Guid>(nullable: false),
                    RegionCode = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    RegionName = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_Region", x => x.rowguid);
                    table.ForeignKey(
                        name: "FK_Master_Region_Master_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Master_Countries",
                        principalColumn: "rowguid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Master_Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CityCode = table.Column<int>(nullable: false),
                    CityName = table.Column<string>(nullable: true),
                    RegionCode = table.Column<string>(nullable: true),
                    RegionId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Master_Cities_Master_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Master_Region",
                        principalColumn: "rowguid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    RegionId = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    DateOfSale = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Master_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Master_Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "rowguid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Master_Cities_RegionId",
                table: "Master_Cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Master_Region_CountryId",
                table: "Master_Region",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CityId",
                table: "Sales",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Master_Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Master_Cities");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Master_Region");

            migrationBuilder.DropTable(
                name: "Master_Countries");
        }
    }
}
