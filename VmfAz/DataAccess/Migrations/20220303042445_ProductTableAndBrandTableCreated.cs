using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ProductTableAndBrandTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    PosterImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HexValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductBeltTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBeltTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCaseMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCaseMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCaseShapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCaseShapes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCaseSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCaseSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductFunctionalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFunctionalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductGlassTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGlassTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductMechanisms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMechanisms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductionCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductionCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductStyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductWaterResistances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResistanceValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWaterResistances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    ProductFunctionalityId = table.Column<int>(type: "int", nullable: false),
                    ToolCount = table.Column<int>(type: "int", nullable: true),
                    WarrantyLimit = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    ProductStyleId = table.Column<int>(type: "int", nullable: true),
                    ProductWaterResistanceId = table.Column<int>(type: "int", nullable: true),
                    ProductProductionCountryId = table.Column<int>(type: "int", nullable: true),
                    ProductMechanismId = table.Column<int>(type: "int", nullable: true),
                    ProductGlassTypeId = table.Column<int>(type: "int", nullable: true),
                    ProductCaseMaterialId = table.Column<int>(type: "int", nullable: true),
                    ProductCaseShapeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductCaseMaterials_ProductCaseMaterialId",
                        column: x => x.ProductCaseMaterialId,
                        principalTable: "ProductCaseMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductCaseShapes_ProductCaseShapeId",
                        column: x => x.ProductCaseShapeId,
                        principalTable: "ProductCaseShapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductFunctionalities_ProductFunctionalityId",
                        column: x => x.ProductFunctionalityId,
                        principalTable: "ProductFunctionalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductGlassTypes_ProductGlassTypeId",
                        column: x => x.ProductGlassTypeId,
                        principalTable: "ProductGlassTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductMechanisms_ProductMechanismId",
                        column: x => x.ProductMechanismId,
                        principalTable: "ProductMechanisms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductProductionCountries_ProductProductionCountryId",
                        column: x => x.ProductProductionCountryId,
                        principalTable: "ProductProductionCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductStyles_ProductStyleId",
                        column: x => x.ProductStyleId,
                        principalTable: "ProductStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductWaterResistances_ProductWaterResistanceId",
                        column: x => x.ProductWaterResistanceId,
                        principalTable: "ProductWaterResistances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductBeltTypeId = table.Column<int>(type: "int", nullable: false),
                    ProductCaseSizeId = table.Column<int>(type: "int", nullable: false),
                    ProductBeltColorId = table.Column<int>(type: "int", nullable: false),
                    ProductDialColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductEntries_Colors_ProductBeltColorId",
                        column: x => x.ProductBeltColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductEntries_Colors_ProductDialColorId",
                        column: x => x.ProductDialColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductEntries_ProductBeltTypes_ProductBeltTypeId",
                        column: x => x.ProductBeltTypeId,
                        principalTable: "ProductBeltTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductEntries_ProductCaseSizes_ProductCaseSizeId",
                        column: x => x.ProductCaseSizeId,
                        principalTable: "ProductCaseSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductEntries_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntries_ProductBeltColorId",
                table: "ProductEntries",
                column: "ProductBeltColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntries_ProductBeltTypeId",
                table: "ProductEntries",
                column: "ProductBeltTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntries_ProductCaseSizeId",
                table: "ProductEntries",
                column: "ProductCaseSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntries_ProductDialColorId",
                table: "ProductEntries",
                column: "ProductDialColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntries_ProductId",
                table: "ProductEntries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GenderId",
                table: "Products",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCaseMaterialId",
                table: "Products",
                column: "ProductCaseMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCaseShapeId",
                table: "Products",
                column: "ProductCaseShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductFunctionalityId",
                table: "Products",
                column: "ProductFunctionalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGlassTypeId",
                table: "Products",
                column: "ProductGlassTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductMechanismId",
                table: "Products",
                column: "ProductMechanismId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductProductionCountryId",
                table: "Products",
                column: "ProductProductionCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductStyleId",
                table: "Products",
                column: "ProductStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductWaterResistanceId",
                table: "Products",
                column: "ProductWaterResistanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductEntries");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "ProductBeltTypes");

            migrationBuilder.DropTable(
                name: "ProductCaseSizes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "ProductCaseMaterials");

            migrationBuilder.DropTable(
                name: "ProductCaseShapes");

            migrationBuilder.DropTable(
                name: "ProductFunctionalities");

            migrationBuilder.DropTable(
                name: "ProductGlassTypes");

            migrationBuilder.DropTable(
                name: "ProductMechanisms");

            migrationBuilder.DropTable(
                name: "ProductProductionCountries");

            migrationBuilder.DropTable(
                name: "ProductStyles");

            migrationBuilder.DropTable(
                name: "ProductWaterResistances");
        }
    }
}
