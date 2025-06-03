using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutipSmart.Migrations
{
    /// <inheritdoc />
    public partial class imantu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Bin",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Bin",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TruckId",
                table: "Bin",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bin_TruckId",
                table: "Bin",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bin_Trucks_TruckId",
                table: "Bin",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "TruckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bin_Trucks_TruckId",
                table: "Bin");

            migrationBuilder.DropIndex(
                name: "IX_Bin_TruckId",
                table: "Bin");

            migrationBuilder.DropColumn(
                name: "DistanceToNext",
                table: "Bin");

            migrationBuilder.DropColumn(
                name: "DurationToNext",
                table: "Bin");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Bin");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Bin");

            migrationBuilder.DropColumn(
                name: "TruckId",
                table: "Bin");
        }
    }
}
