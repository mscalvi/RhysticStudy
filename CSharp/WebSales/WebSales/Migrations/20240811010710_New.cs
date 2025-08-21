using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSales.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersTournaments");

            migrationBuilder.AlterColumn<int>(
                name: "TournamentsId",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TournamentsId",
                table: "Players",
                column: "TournamentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Tournaments_TournamentsId",
                table: "Players",
                column: "TournamentsId",
                principalTable: "Tournaments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Tournaments_TournamentsId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_TournamentsId",
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

            migrationBuilder.CreateTable(
                name: "PlayersTournaments",
                columns: table => new
                {
                    PlayersId = table.Column<int>(type: "int", nullable: false),
                    TournamentsPlayedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersTournaments", x => new { x.PlayersId, x.TournamentsPlayedId });
                    table.ForeignKey(
                        name: "FK_PlayersTournaments_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayersTournaments_Tournaments_TournamentsPlayedId",
                        column: x => x.TournamentsPlayedId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersTournaments_TournamentsPlayedId",
                table: "PlayersTournaments",
                column: "TournamentsPlayedId");
        }
    }
}
