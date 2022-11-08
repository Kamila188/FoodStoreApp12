using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodStoreApp.Migrations
{
    public partial class AddproductTableToDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufacturerID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManufacturersId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ManufacturersId",
                table: "Product",
                column: "ManufacturersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Manufacturers_ManufacturersId",
                table: "Product",
                column: "ManufacturersId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Manufacturers_ManufacturersId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ManufacturersId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ManufacturerID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ManufacturersId",
                table: "Product");
        }
    }
}
