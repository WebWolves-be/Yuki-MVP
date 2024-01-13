using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yuki.Common.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoicesMatchesRelationshipV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Matches_MatchId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_MatchId",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "Matches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_InvoiceId",
                table: "Matches",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Invoices_InvoiceId",
                table: "Matches",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Invoices_InvoiceId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_InvoiceId",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_MatchId",
                table: "Invoices",
                column: "MatchId",
                unique: true,
                filter: "[MatchId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Matches_MatchId",
                table: "Invoices",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");
        }
    }
}
