using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutipSmart.Migrations
{
    /// <inheritdoc />
    public partial class addStatusDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bin",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bin");
        }
    }
}
