using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Board.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ModifyGeneralBoardColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Boards");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Boards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Boards");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
