using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSales.Migrations
{
    /// <inheritdoc />
    public partial class Cansei : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Tournaments_TournamentsId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "TournamentsId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Tournaments_TournamentsId",
                table: "Players",
                column: "TournamentsId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Tournaments_TournamentsId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "TournamentsId",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Tournaments_TournamentsId",
                table: "Players",
                column: "TournamentsId",
                principalTable: "Tournaments",
                principalColumn: "Id");
        }
    }
}
