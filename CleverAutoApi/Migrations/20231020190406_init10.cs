using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleverAutoApi.Migrations
{
    /// <inheritdoc />
    public partial class init10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UseOfCarPerDay",
                table: "Cars",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearOfFirstUse",
                table: "Cars",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseOfCarPerDay",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "YearOfFirstUse",
                table: "Cars");
        }
    }
}
