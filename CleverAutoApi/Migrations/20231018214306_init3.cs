using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleverAutoApi.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mileage",
                table: "Cars",
                newName: "EstimatedNextServiceMileage");

            migrationBuilder.AddColumn<int>(
                name: "CurrentMileage",
                table: "Cars",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentMileage",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "EstimatedNextServiceMileage",
                table: "Cars",
                newName: "Mileage");
        }
    }
}
