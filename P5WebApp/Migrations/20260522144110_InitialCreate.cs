using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "FinishTypes",
                columns: table => new
                {
                    FinishTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinishTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinishTypes", x => x.FinishTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ShortAdds",
                columns: table => new
                {
                    ShortAddId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortAddAvailabilityDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ShortAddDateSold = table.Column<DateOnly>(type: "date", nullable: false),
                    ShortAddSold = table.Column<bool>(type: "bit", nullable: false),
                    ShortAddCarId = table.Column<int>(type: "int", nullable: false),
                    ShortAddBuyPrice = table.Column<double>(type: "float", nullable: false),
                    ShortAddSellingPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortAdds", x => x.ShortAddId);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AsociatedBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_Brands_AsociatedBrandId",
                        column: x => x.AsociatedBrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId");
                });

            migrationBuilder.CreateTable(
                name: "BrandFinishType",
                columns: table => new
                {
                    BrandsBrandId = table.Column<int>(type: "int", nullable: false),
                    FinishTypesFinishTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandFinishType", x => new { x.BrandsBrandId, x.FinishTypesFinishTypeId });
                    table.ForeignKey(
                        name: "FK_BrandFinishType_Brands_BrandsBrandId",
                        column: x => x.BrandsBrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandFinishType_FinishTypes_FinishTypesFinishTypeId",
                        column: x => x.FinishTypesFinishTypeId,
                        principalTable: "FinishTypes",
                        principalColumn: "FinishTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssociatedShortAddId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_ShortAdds_AssociatedShortAddId",
                        column: x => x.AssociatedShortAddId,
                        principalTable: "ShortAdds",
                        principalColumn: "ShortAddId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarModelFinishType",
                columns: table => new
                {
                    CarModelsId = table.Column<int>(type: "int", nullable: false),
                    FinishTypesFinishTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModelFinishType", x => new { x.CarModelsId, x.FinishTypesFinishTypeId });
                    table.ForeignKey(
                        name: "FK_CarModelFinishType_CarModels_CarModelsId",
                        column: x => x.CarModelsId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModelFinishType_FinishTypes_FinishTypesFinishTypeId",
                        column: x => x.FinishTypesFinishTypeId,
                        principalTable: "FinishTypes",
                        principalColumn: "FinishTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarVinCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarYear = table.Column<DateOnly>(type: "date", nullable: false),
                    CarBuyDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CarBuyPrice = table.Column<double>(type: "float", nullable: false),
                    CarBrandId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    CarFinishTypeId = table.Column<int>(type: "int", nullable: false),
                    FinishTypeId = table.Column<int>(type: "int", nullable: true),
                    AssociatedShortAddId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId");
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_FinishTypes_FinishTypeId",
                        column: x => x.FinishTypeId,
                        principalTable: "FinishTypes",
                        principalColumn: "FinishTypeId");
                    table.ForeignKey(
                        name: "FK_Cars_ShortAdds_AssociatedShortAddId",
                        column: x => x.AssociatedShortAddId,
                        principalTable: "ShortAdds",
                        principalColumn: "ShortAddId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fixes",
                columns: table => new
                {
                    FixId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FixDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FixDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FixCost = table.Column<double>(type: "float", nullable: false),
                    AssociatedCarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixes", x => x.FixId);
                    table.ForeignKey(
                        name: "FK_Fixes_Cars_AssociatedCarId",
                        column: x => x.AssociatedCarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandFinishType_FinishTypesFinishTypeId",
                table: "BrandFinishType",
                column: "FinishTypesFinishTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelFinishType_FinishTypesFinishTypeId",
                table: "CarModelFinishType",
                column: "FinishTypesFinishTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_AsociatedBrandId",
                table: "CarModels",
                column: "AsociatedBrandId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Fixes_AssociatedCarId",
                table: "Fixes",
                column: "AssociatedCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AssociatedShortAddId",
                table: "Photos",
                column: "AssociatedShortAddId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandFinishType");

            migrationBuilder.DropTable(
                name: "CarModelFinishType");

            migrationBuilder.DropTable(
                name: "Fixes");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "FinishTypes");

            migrationBuilder.DropTable(
                name: "ShortAdds");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
