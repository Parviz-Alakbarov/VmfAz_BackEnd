using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ProductEntryTableRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductEntries");

            migrationBuilder.AddColumn<int>(
                name: "ProductBeltColorId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductBeltTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductCaseSizeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductDialColorId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBeltColorId",
                table: "Products",
                column: "ProductBeltColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBeltTypeId",
                table: "Products",
                column: "ProductBeltTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCaseSizeId",
                table: "Products",
                column: "ProductCaseSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDialColorId",
                table: "Products",
                column: "ProductDialColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Colors_ProductBeltColorId",
                table: "Products",
                column: "ProductBeltColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Colors_ProductDialColorId",
                table: "Products",
                column: "ProductDialColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductBeltTypes_ProductBeltTypeId",
                table: "Products",
                column: "ProductBeltTypeId",
                principalTable: "ProductBeltTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCaseSizes_ProductCaseSizeId",
                table: "Products",
                column: "ProductCaseSizeId",
                principalTable: "ProductCaseSizes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Colors_ProductBeltColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Colors_ProductDialColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductBeltTypes_ProductBeltTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCaseSizes_ProductCaseSizeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductBeltColorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductBeltTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCaseSizeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductDialColorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductBeltColorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductBeltTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCaseSizeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductDialColorId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductBeltColorId = table.Column<int>(type: "int", nullable: true),
                    ProductBeltTypeId = table.Column<int>(type: "int", nullable: true),
                    ProductCaseSizeId = table.Column<int>(type: "int", nullable: true),
                    ProductDialColorId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductEntries_ProductCaseSizes_ProductCaseSizeId",
                        column: x => x.ProductCaseSizeId,
                        principalTable: "ProductCaseSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
        }
    }
}
