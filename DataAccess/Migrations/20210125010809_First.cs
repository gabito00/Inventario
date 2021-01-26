using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Wherehouses",
                columns: table => new
                {
                    WarehouseID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WarehouseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WarehouseAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wherehouses", x => x.WarehouseID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    StorageID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartialQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    WarehouseID = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.StorageID);
                    table.ForeignKey(
                        name: "FK_Storages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Storages_Wherehouses_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "Wherehouses",
                        principalColumn: "WarehouseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InOut",
                columns: table => new
                {
                    InOutID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsInput = table.Column<bool>(type: "bit", nullable: false),
                    StorageID = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InOut", x => x.InOutID);
                    table.ForeignKey(
                        name: "FK_InOut_Storages_StorageID",
                        column: x => x.StorageID,
                        principalTable: "Storages",
                        principalColumn: "StorageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { "ASH", "Aseo Hogar" },
                    { "ASP", "Aseo Personal" },
                    { "HGR", "Hogar" },
                    { "PRF", "Perfumería" },
                    { "SLD", "Salud" },
                    { "VDJ", "Video Juegos" }
                });

            migrationBuilder.InsertData(
                table: "Wherehouses",
                columns: new[] { "WarehouseID", "WarehouseAddress", "WarehouseName" },
                values: new object[,]
                {
                    { "004554b7-1128-43a7-9942-3dab5304d49e", "Av. Rivadavia 10000", "Bodega Central" },
                    { "63895671-7dbe-4bf8-92b8-4d65eb97ed05", "Av. Rivadavia", "Bodega Gran BsAs" },
                    { "3ecfacd5-f8b5-472a-91a9-7ea476cf48a1", "Dirección Desconocida", "Bodega Norte" },
                    { "57be573d-0494-4b36-ba7f-63b79364af30", "Dirección Desconocida", "Bodega Centro" },
                    { "06a4f4f8-f206-4397-b61d-49f15aa6d241", "Dirección Desconocida", "Bodega Sur" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InOut_StorageID",
                table: "InOut",
                column: "StorageID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_ProductID",
                table: "Storages",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_WarehouseID",
                table: "Storages",
                column: "WarehouseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InOut");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Wherehouses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
