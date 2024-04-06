using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class LMS2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Borrowings_BorrowingModelId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BorrowingModelId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Borrowings_BorrowingModelId",
                table: "Books",
                column: "BorrowingModelId",
                principalTable: "Borrowings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Borrowings_BorrowingModelId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BorrowingModelId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Borrowings_BorrowingModelId",
                table: "Books",
                column: "BorrowingModelId",
                principalTable: "Borrowings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
