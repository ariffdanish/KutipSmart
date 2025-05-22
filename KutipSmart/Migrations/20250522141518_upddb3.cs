using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutipSmart.Migrations
{
    /// <inheritdoc />
    public partial class upddb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Trucks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Trucks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
