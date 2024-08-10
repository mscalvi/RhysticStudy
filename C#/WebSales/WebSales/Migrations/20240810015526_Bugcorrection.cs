using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSales.Migrations
{
    /// <inheritdoc />
    public partial class Bugcorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Decks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Tournaments",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Decks",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
