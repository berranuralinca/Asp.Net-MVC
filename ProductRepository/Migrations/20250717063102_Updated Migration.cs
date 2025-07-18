using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductRepository.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Visitors",
                newName: "VisitorName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisitorName",
                table: "Visitors",
                newName: "Name");
        }
    }
}
