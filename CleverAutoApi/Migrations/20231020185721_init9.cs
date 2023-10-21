using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleverAutoApi.Migrations
{
    /// <inheritdoc />
    public partial class init9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedNextServiceMileage",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "EstimatedNextServiceMileage",
                table: "Services",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedNextServiceMileage",
                table: "Services");

            migrationBuilder.AddColumn<int>(
                name: "EstimatedNextServiceMileage",
                table: "Cars",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
