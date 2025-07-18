using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductRepository.Migrations
{
    /// <inheritdoc />
    public partial class datemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ProductDate",
                table: "Products",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductDate",
                table: "Products");
        }
    }
}
