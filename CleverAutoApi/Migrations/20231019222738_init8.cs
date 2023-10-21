using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleverAutoApi.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_CustomerId",
                table: "Cars");

            migrationBuilder.AddColumn<bool>(
                name: "ReminderSent",
                table: "Services",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CustomerId",
                table: "Cars",
                column: "CustomerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_CustomerId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ReminderSent",
                table: "Services");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CustomerId",
                table: "Cars",
                column: "CustomerId");
        }
    }
}
