using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration3060526 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixes_Cars_AssociatedCarId",
                table: "Fixes");

            migrationBuilder.DropIndex(
                name: "IX_Fixes_AssociatedCarId",
                table: "Fixes");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Fixes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fixes_CarId",
                table: "Fixes",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fixes_Cars_CarId",
                table: "Fixes",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixes_Cars_CarId",
                table: "Fixes");

            migrationBuilder.DropIndex(
                name: "IX_Fixes_CarId",
                table: "Fixes");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Fixes");

            migrationBuilder.CreateIndex(
                name: "IX_Fixes_AssociatedCarId",
                table: "Fixes",
                column: "AssociatedCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fixes_Cars_AssociatedCarId",
                table: "Fixes",
                column: "AssociatedCarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
