using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5WebApp.Migrations
{
    /// <inheritdoc />
    public partial class MigrationForPhotos061726 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_ShortAdds_AssociatedShortAddId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_AssociatedShortAddId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "AssociatedShortAddId",
                table: "Photos",
                newName: "AssociatedCarId");

            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShortAddId",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ShortAddId",
                table: "Photos",
                column: "ShortAddId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_ShortAdds_ShortAddId",
                table: "Photos",
                column: "ShortAddId",
                principalTable: "ShortAdds",
                principalColumn: "ShortAddId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_ShortAdds_ShortAddId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_ShortAddId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ShortAddId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "AssociatedCarId",
                table: "Photos",
                newName: "AssociatedShortAddId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AssociatedShortAddId",
                table: "Photos",
                column: "AssociatedShortAddId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_ShortAdds_AssociatedShortAddId",
                table: "Photos",
                column: "AssociatedShortAddId",
                principalTable: "ShortAdds",
                principalColumn: "ShortAddId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
