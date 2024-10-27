using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace music.Migrations
{
    /// <inheritdoc />
    public partial class SeedMusicTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "songs",
                columns: new[] { "Id", "duration", "language", "title" },
                values: new object[,]
                {
                    { 1, "3.21", "en", "vasylky" },
                    { 2, "4.31", "uk", "dmytroloh" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
