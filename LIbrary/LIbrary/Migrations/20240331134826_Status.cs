using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIbrary.Migrations
{
    /// <inheritdoc />
    public partial class Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "borrowItemStatusId",
                table: "BorrowItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BorrowItemStatus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowItemStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowItem_borrowItemStatusId",
                table: "BorrowItem",
                column: "borrowItemStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowItem_BorrowItemStatus_borrowItemStatusId",
                table: "BorrowItem",
                column: "borrowItemStatusId",
                principalTable: "BorrowItemStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowItem_BorrowItemStatus_borrowItemStatusId",
                table: "BorrowItem");

            migrationBuilder.DropTable(
                name: "BorrowItemStatus");

            migrationBuilder.DropIndex(
                name: "IX_BorrowItem_borrowItemStatusId",
                table: "BorrowItem");

            migrationBuilder.DropColumn(
                name: "borrowItemStatusId",
                table: "BorrowItem");
        }
    }
}
