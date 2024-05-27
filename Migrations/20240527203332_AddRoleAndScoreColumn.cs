using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_REST_GAME_PROJECT.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleAndScoreColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "User");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0); // Aquí puedes ajustar las opciones según sea necesario
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Users");
        }
    }
}
