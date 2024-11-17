using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryService.Migrations
{
    /// <inheritdoc />
    public partial class stockbook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookStockEntries",
                columns: table => new
                {
                    BookStockEntryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookFormatConnectionId = table.Column<int>(type: "INTEGER", nullable: false),
                    StockCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStockEntries", x => x.BookStockEntryId);
                    table.ForeignKey(
                        name: "FK_BookStockEntries_BookFormatConnections_BookFormatConnectionId",
                        column: x => x.BookFormatConnectionId,
                        principalTable: "BookFormatConnections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookStockEntries_BookFormatConnectionId",
                table: "BookStockEntries",
                column: "BookFormatConnectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookStockEntries");
        }
    }
}
