using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration060226 : Migration
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
                name: "FK_Cars_Brands_BrandId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FinishTypes_FinishTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_ShortAdds_AssociatedShortAddId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixes_Cars_AssociatedCarId",
                table: "Fixes");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_ShortAdds_AssociatedShortAddId",
                table: "Photos");

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
                name: "FK_Cars_Brands_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_FinishTypes_FinishTypeId",
                table: "Cars",
                column: "FinishTypeId",
                principalTable: "FinishTypes",
                principalColumn: "FinishTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_ShortAdds_AssociatedShortAddId",
                table: "Cars",
                column: "AssociatedShortAddId",
                principalTable: "ShortAdds",
                principalColumn: "ShortAddId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixes_Cars_AssociatedCarId",
                table: "Fixes",
                column: "AssociatedCarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_ShortAdds_AssociatedShortAddId",
                table: "Photos",
                column: "AssociatedShortAddId",
                principalTable: "ShortAdds",
                principalColumn: "ShortAddId",
                onDelete: ReferentialAction.Restrict);
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
                name: "FK_Cars_Brands_BrandId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FinishTypes_FinishTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_ShortAdds_AssociatedShortAddId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixes_Cars_AssociatedCarId",
                table: "Fixes");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_ShortAdds_AssociatedShortAddId",
                table: "Photos");

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
                name: "FK_Cars_Brands_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_FinishTypes_FinishTypeId",
                table: "Cars",
                column: "FinishTypeId",
                principalTable: "FinishTypes",
                principalColumn: "FinishTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_ShortAdds_AssociatedShortAddId",
                table: "Cars",
                column: "AssociatedShortAddId",
                principalTable: "ShortAdds",
                principalColumn: "ShortAddId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixes_Cars_AssociatedCarId",
                table: "Fixes",
                column: "AssociatedCarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_ShortAdds_AssociatedShortAddId",
                table: "Photos",
                column: "AssociatedShortAddId",
                principalTable: "ShortAdds",
                principalColumn: "ShortAddId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
