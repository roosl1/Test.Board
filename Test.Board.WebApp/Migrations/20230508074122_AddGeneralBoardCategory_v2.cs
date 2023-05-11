using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Board.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddGeneralBoardCategory_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralBoardCategory",
                table: "GeneralBoardCategory");

            migrationBuilder.RenameTable(
                name: "GeneralBoardCategory",
                newName: "BoardCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardCategories",
                table: "BoardCategories",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardCategories",
                table: "BoardCategories");

            migrationBuilder.RenameTable(
                name: "BoardCategories",
                newName: "GeneralBoardCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralBoardCategory",
                table: "GeneralBoardCategory",
                column: "Id");
        }
    }
}
