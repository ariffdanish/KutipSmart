using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutipSmart.Migrations
{
    /// <inheritdoc />
    public partial class tu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistanceToNext",
                table: "Bin");

            migrationBuilder.DropColumn(
                name: "DurationToNext",
                table: "Bin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DistanceToNext",
                table: "Bin",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DurationToNext",
                table: "Bin",
                type: "float",
                nullable: true);
        }
    }
}
