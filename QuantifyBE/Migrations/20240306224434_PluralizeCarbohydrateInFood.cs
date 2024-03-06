using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuantifyBE.Migrations
{
    /// <inheritdoc />
    public partial class PluralizeCarbohydrateInFood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Carbohydrate",
                table: "Food",
                newName: "Carbohydrates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Carbohydrates",
                table: "Food",
                newName: "Carbohydrate");
        }
    }
}
