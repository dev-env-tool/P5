using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P5WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration060326 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssociatedFixIds",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssociatedFixIds",
                table: "Cars");
        }
    }
}
