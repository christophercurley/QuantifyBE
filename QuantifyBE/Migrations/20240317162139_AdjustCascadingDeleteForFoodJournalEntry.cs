using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuantifyBE.Migrations
{
    /// <inheritdoc />
    public partial class AdjustCascadingDeleteForFoodJournalEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_Foods_FoodId",
                table: "JournalEntries");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_Foods_FoodId",
                table: "JournalEntries",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_Foods_FoodId",
                table: "JournalEntries");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_Foods_FoodId",
                table: "JournalEntries",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id");
        }
    }
}
