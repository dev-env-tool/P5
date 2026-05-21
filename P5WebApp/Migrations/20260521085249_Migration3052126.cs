using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration3052126 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortAdds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortAddAvailabilityDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ShortAddDateSold = table.Column<DateOnly>(type: "date", nullable: false),
                    ShortAddSold = table.Column<bool>(type: "bit", nullable: false),
                    ShortAddCarId = table.Column<int>(type: "int", nullable: false),
                    ShortAddBuyPrice = table.Column<double>(type: "float", nullable: false),
                    ShortAddSellingPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortAdds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PhotoId = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssociatedShortAddId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_ShortAdds_AssociatedShortAddId",
                        column: x => x.AssociatedShortAddId,
                        principalTable: "ShortAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photos_ShortAdds_Id",
                        column: x => x.Id,
                        principalTable: "ShortAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarVinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarYear = table.Column<DateOnly>(type: "date", nullable: false),
                    CarBuyDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CarBuyPrice = table.Column<double>(type: "float", nullable: false),
                    CarBrandId = table.Column<int>(type: "int", nullable: false),
                    BrandCarId = table.Column<int>(type: "int", nullable: true),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    CarFinishTypeId = table.Column<int>(type: "int", nullable: false),
                    AssociatedShortAddId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandCarId",
                        column: x => x.BrandCarId,
                        principalTable: "Brands",
                        principalColumn: "CarId");
                    table.ForeignKey(
                        name: "FK_Cars_ShortAdds_AssociatedShortAddId",
                        column: x => x.AssociatedShortAddId,
                        principalTable: "ShortAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinishTypes",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    FinishTypeId = table.Column<int>(type: "int", nullable: false),
                    FinishTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssociatedCarId = table.Column<int>(type: "int", nullable: false),
                    AssociatedCarModelId = table.Column<int>(type: "int", nullable: false),
                    AssociatedBrandId = table.Column<int>(type: "int", nullable: false),
                    FinishTypeCarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinishTypes", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_FinishTypes_Brands_AssociatedBrandId",
                        column: x => x.AssociatedBrandId,
                        principalTable: "Brands",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinishTypes_Cars_AssociatedCarId",
                        column: x => x.AssociatedCarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinishTypes_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinishTypes_FinishTypes_FinishTypeCarId",
                        column: x => x.FinishTypeCarId,
                        principalTable: "FinishTypes",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fixes",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    FixId = table.Column<int>(type: "int", nullable: false),
                    FixDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FixDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FixCost = table.Column<double>(type: "float", nullable: false),
                    AssociatedCarId = table.Column<int>(type: "int", nullable: false),
                    FinishTypeCarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixes", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Fixes_Cars_AssociatedCarId",
                        column: x => x.AssociatedCarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fixes_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fixes_FinishTypes_FinishTypeCarId",
                        column: x => x.FinishTypeCarId,
                        principalTable: "FinishTypes",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AsociatedBrandId = table.Column<int>(type: "int", nullable: false),
                    FinishTypeCarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Models_Brands_AsociatedBrandId",
                        column: x => x.AsociatedBrandId,
                        principalTable: "Brands",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_FinishTypes_FinishTypeCarId",
                        column: x => x.FinishTypeCarId,
                        principalTable: "FinishTypes",
                        principalColumn: "CarId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_BrandId",
                table: "Brands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CarId",
                table: "Brands",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AssociatedShortAddId",
                table: "Cars",
                column: "AssociatedShortAddId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandCarId",
                table: "Cars",
                column: "BrandCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarId",
                table: "Cars",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FinishTypes_AssociatedBrandId",
                table: "FinishTypes",
                column: "AssociatedBrandId",
                unique: true,
                filter: "[AssociatedBrandId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FinishTypes_AssociatedCarId",
                table: "FinishTypes",
                column: "AssociatedCarId");

            migrationBuilder.CreateIndex(
                name: "IX_FinishTypes_AssociatedCarModelId",
                table: "FinishTypes",
                column: "AssociatedCarModelId",
                unique: true,
                filter: "[AssociatedCarModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FinishTypes_CarId",
                table: "FinishTypes",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinishTypes_FinishTypeCarId",
                table: "FinishTypes",
                column: "FinishTypeCarId");

            migrationBuilder.CreateIndex(
                name: "IX_FinishTypes_FinishTypeId",
                table: "FinishTypes",
                column: "FinishTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixes_AssociatedCarId",
                table: "Fixes",
                column: "AssociatedCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixes_CarId",
                table: "Fixes",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fixes_FinishTypeCarId",
                table: "Fixes",
                column: "FinishTypeCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixes_FixId",
                table: "Fixes",
                column: "FixId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_AsociatedBrandId",
                table: "Models",
                column: "AsociatedBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_CarId",
                table: "Models",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_FinishTypeCarId",
                table: "Models",
                column: "FinishTypeCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Id",
                table: "Models",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AssociatedShortAddId",
                table: "Photos",
                column: "AssociatedShortAddId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_Id",
                table: "Photos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShortAdds_Id",
                table: "ShortAdds",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Cars_CarId",
                table: "Brands",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "Models",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinishTypes_Models_AssociatedCarModelId",
                table: "FinishTypes",
                column: "AssociatedCarModelId",
                principalTable: "Models",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Cars_CarId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_FinishTypes_Cars_AssociatedCarId",
                table: "FinishTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_FinishTypes_Cars_CarId",
                table: "FinishTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Cars_CarId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_FinishTypes_Brands_AssociatedBrandId",
                table: "FinishTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_AsociatedBrandId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_FinishTypes_Models_AssociatedCarModelId",
                table: "FinishTypes");

            migrationBuilder.DropTable(
                name: "Fixes");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "ShortAdds");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "FinishTypes");
        }
    }
}
