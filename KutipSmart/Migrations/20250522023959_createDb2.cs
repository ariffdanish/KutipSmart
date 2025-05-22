using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutipSmart.Migrations
{
    /// <inheritdoc />
    public partial class createDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RouteStops",
                table: "RouteStops");

            migrationBuilder.RenameTable(
                name: "RouteStops",
                newName: "Bin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bin",
                table: "Bin",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bin",
                table: "Bin");

            migrationBuilder.RenameTable(
                name: "Bin",
                newName: "RouteStops");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouteStops",
                table: "RouteStops",
                column: "Id");
        }
    }
}
