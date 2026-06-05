using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration060426 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropIndex(
                name: "IX_Cars_AssociatedShortAddId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_BrandId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_FinishTypeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AssociatedShortAddId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FinishTypeId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "ShortAdds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShortAdds_CarId",
                table: "ShortAdds",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShortAdds_Cars_CarId",
                table: "ShortAdds",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShortAdds_Cars_CarId",
                table: "ShortAdds");

            migrationBuilder.DropIndex(
                name: "IX_ShortAdds_CarId",
                table: "ShortAdds");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "ShortAdds");

            migrationBuilder.AddColumn<int>(
                name: "AssociatedShortAddId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinishTypeId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AssociatedShortAddId",
                table: "Cars",
                column: "AssociatedShortAddId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FinishTypeId",
                table: "Cars",
                column: "FinishTypeId");

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
        }
    }
}
