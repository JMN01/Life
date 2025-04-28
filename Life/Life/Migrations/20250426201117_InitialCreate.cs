using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Personals_PersonalId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalId",
                table: "Members",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Personals_PersonalId",
                table: "Members",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "PersonalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Personals_PersonalId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Personals_PersonalId",
                table: "Members",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "PersonalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
