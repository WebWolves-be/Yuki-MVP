using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yuki.Common.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoicesMatchesRelationshipV5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Invoices_InvoiceId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Invoices");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Invoices_InvoiceId",
                table: "Matches",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Invoices_InvoiceId",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Invoices_InvoiceId",
                table: "Matches",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");
        }
    }
}
