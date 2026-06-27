using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration202606275 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandFinishType_Brands_BrandsBrandId",
                table: "BrandFinishType");

            migrationBuilder.DropForeignKey(
                name: "FK_BrandFinishType_FinishTypes_FinishTypesFinishTypeId",
                table: "BrandFinishType");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModelFinishType_CarModels_CarModelsId",
                table: "CarModelFinishType");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModelFinishType_FinishTypes_FinishTypesFinishTypeId",
                table: "CarModelFinishType");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixes_Cars_CarId",
                table: "Fixes");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Fixes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandFinishType_Brands_BrandsBrandId",
                table: "BrandFinishType",
                column: "BrandsBrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BrandFinishType_FinishTypes_FinishTypesFinishTypeId",
                table: "BrandFinishType",
                column: "FinishTypesFinishTypeId",
                principalTable: "FinishTypes",
                principalColumn: "FinishTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelFinishType_CarModels_CarModelsId",
                table: "CarModelFinishType",
                column: "CarModelsId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelFinishType_FinishTypes_FinishTypesFinishTypeId",
                table: "CarModelFinishType",
                column: "FinishTypesFinishTypeId",
                principalTable: "FinishTypes",
                principalColumn: "FinishTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixes_Cars_CarId",
                table: "Fixes",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandFinishType_Brands_BrandsBrandId",
                table: "BrandFinishType");

            migrationBuilder.DropForeignKey(
                name: "FK_BrandFinishType_FinishTypes_FinishTypesFinishTypeId",
                table: "BrandFinishType");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModelFinishType_CarModels_CarModelsId",
                table: "CarModelFinishType");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModelFinishType_FinishTypes_FinishTypesFinishTypeId",
                table: "CarModelFinishType");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixes_Cars_CarId",
                table: "Fixes");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Fixes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BrandFinishType_Brands_BrandsBrandId",
                table: "BrandFinishType",
                column: "BrandsBrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BrandFinishType_FinishTypes_FinishTypesFinishTypeId",
                table: "BrandFinishType",
                column: "FinishTypesFinishTypeId",
                principalTable: "FinishTypes",
                principalColumn: "FinishTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelFinishType_CarModels_CarModelsId",
                table: "CarModelFinishType",
                column: "CarModelsId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelFinishType_FinishTypes_FinishTypesFinishTypeId",
                table: "CarModelFinishType",
                column: "FinishTypesFinishTypeId",
                principalTable: "FinishTypes",
                principalColumn: "FinishTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixes_Cars_CarId",
                table: "Fixes",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
