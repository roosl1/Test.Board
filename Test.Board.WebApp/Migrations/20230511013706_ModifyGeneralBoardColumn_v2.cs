using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Board.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ModifyGeneralBoardColumn_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Boards");
        }
    }
}
