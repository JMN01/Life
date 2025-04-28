using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_PersonalId",
                table: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PersonalId",
                table: "Members",
                column: "PersonalId",
                unique: true,
                filter: "[PersonalId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_PersonalId",
                table: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PersonalId",
                table: "Members",
                column: "PersonalId");
        }
    }
}
