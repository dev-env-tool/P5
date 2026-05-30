using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration053026 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Brands_AsociatedBrandId",
                table: "CarModels");

            migrationBuilder.RenameColumn(
                name: "AsociatedBrandId",
                table: "CarModels",
                newName: "AssociatedBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_CarModels_AsociatedBrandId",
                table: "CarModels",
                newName: "IX_CarModels_AssociatedBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Brands_AssociatedBrandId",
                table: "CarModels",
                column: "AssociatedBrandId",
                principalTable: "Brands",
                principalColumn: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Brands_AssociatedBrandId",
                table: "CarModels");

            migrationBuilder.RenameColumn(
                name: "AssociatedBrandId",
                table: "CarModels",
                newName: "AsociatedBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_CarModels_AssociatedBrandId",
                table: "CarModels",
                newName: "IX_CarModels_AsociatedBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Brands_AsociatedBrandId",
                table: "CarModels",
                column: "AsociatedBrandId",
                principalTable: "Brands",
                principalColumn: "BrandId");
        }
    }
}
