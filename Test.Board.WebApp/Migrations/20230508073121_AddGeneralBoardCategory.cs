using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test.Board.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddGeneralBoardCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GeneralBoardCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralBoardCategory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GeneralBoardCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "유머" },
                    { 2, "지식" },
                    { 3, "기타" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralBoardCategory");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Boards");
        }
    }
}
