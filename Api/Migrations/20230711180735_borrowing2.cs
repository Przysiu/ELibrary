using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class borrowing2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bookid",
                table: "Borrowings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_Bookid",
                table: "Borrowings",
                column: "Bookid");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowings_Books_Bookid",
                table: "Borrowings",
                column: "Bookid",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrowings_Books_Bookid",
                table: "Borrowings");

            migrationBuilder.DropIndex(
                name: "IX_Borrowings_Bookid",
                table: "Borrowings");

            migrationBuilder.DropColumn(
                name: "Bookid",
                table: "Borrowings");
        }
    }
}
