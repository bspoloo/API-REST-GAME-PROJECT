using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_REST_GAME_PROJECT.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoleAndScoreColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "Role",
            table: "Users");

            migrationBuilder.DropColumn(
            name: "Score",
            table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
