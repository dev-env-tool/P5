using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class _20260627 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AssociatedFixIds",
                table: "Cars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Fixes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssociatedFixIds",
                table: "Cars",
                type: "nvarchar(max)",
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
                principalColumn: "CarId");
        }
    }
}
