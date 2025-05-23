using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutipSmart.Migrations
{
    /// <inheritdoc />
    public partial class dbHarriz10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bin",
                newName: "BinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BinId",
                table: "Bin",
                newName: "Id");
        }
    }
}
