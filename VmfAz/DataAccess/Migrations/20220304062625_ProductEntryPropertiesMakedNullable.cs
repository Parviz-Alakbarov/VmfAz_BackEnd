using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ProductEntryPropertiesMakedNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntries_ProductBeltTypes_ProductBeltTypeId",
                table: "ProductEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntries_ProductCaseSizes_ProductCaseSizeId",
                table: "ProductEntries");

            migrationBuilder.AlterColumn<int>(
                name: "ProductDialColorId",
                table: "ProductEntries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCaseSizeId",
                table: "ProductEntries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductBeltTypeId",
                table: "ProductEntries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductBeltColorId",
                table: "ProductEntries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntries_ProductBeltTypes_ProductBeltTypeId",
                table: "ProductEntries",
                column: "ProductBeltTypeId",
                principalTable: "ProductBeltTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntries_ProductCaseSizes_ProductCaseSizeId",
                table: "ProductEntries",
                column: "ProductCaseSizeId",
                principalTable: "ProductCaseSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntries_ProductBeltTypes_ProductBeltTypeId",
                table: "ProductEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntries_ProductCaseSizes_ProductCaseSizeId",
                table: "ProductEntries");

            migrationBuilder.AlterColumn<int>(
                name: "ProductDialColorId",
                table: "ProductEntries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductCaseSizeId",
                table: "ProductEntries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductBeltTypeId",
                table: "ProductEntries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductBeltColorId",
                table: "ProductEntries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntries_ProductBeltTypes_ProductBeltTypeId",
                table: "ProductEntries",
                column: "ProductBeltTypeId",
                principalTable: "ProductBeltTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntries_ProductCaseSizes_ProductCaseSizeId",
                table: "ProductEntries",
                column: "ProductCaseSizeId",
                principalTable: "ProductCaseSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
