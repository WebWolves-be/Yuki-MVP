using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yuki.Common.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexOnInvoiceIdInMatchesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matches_InvoiceId",
                table: "Matches");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_InvoiceId",
                table: "Matches",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matches_InvoiceId",
                table: "Matches");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_InvoiceId",
                table: "Matches",
                column: "InvoiceId");
        }
    }
}
