using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5WebApp.Migrations
{
    /// <inheritdoc />
    public partial class migration061826 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_ShortAdds_ShortAddId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "ShortAdds");

            migrationBuilder.DropIndex(
                name: "IX_Photos_ShortAddId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ShortAddId",
                table: "Photos");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CarAddAvailabilityDate",
                table: "Cars",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CarDateSold",
                table: "Cars",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarDescription",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CarPublished",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "CarSellingPrice",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarAddAvailabilityDate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarDateSold",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarDescription",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarPublished",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarSellingPrice",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "ShortAddId",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShortAdds",
                columns: table => new
                {
                    ShortAddId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortAddAvailabilityDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ShortAddBuyPrice = table.Column<double>(type: "float", nullable: false),
                    ShortAddCarId = table.Column<int>(type: "int", nullable: false),
                    ShortAddDateSold = table.Column<DateOnly>(type: "date", nullable: true),
                    ShortAddPublished = table.Column<bool>(type: "bit", nullable: false),
                    ShortAddSellingPrice = table.Column<double>(type: "float", nullable: false),
                    ShortAddSold = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortAdds", x => x.ShortAddId);
                    table.ForeignKey(
                        name: "FK_ShortAdds_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ShortAddId",
                table: "Photos",
                column: "ShortAddId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortAdds_CarId",
                table: "ShortAdds",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_ShortAdds_ShortAddId",
                table: "Photos",
                column: "ShortAddId",
                principalTable: "ShortAdds",
                principalColumn: "ShortAddId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
