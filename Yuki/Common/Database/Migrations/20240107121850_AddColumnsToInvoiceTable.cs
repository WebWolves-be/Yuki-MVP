using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yuki.Common.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToInvoiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Invoice",
                type: "decimal(15,2)",
                precision: 15,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Invoice",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Invoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Invoice",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "VatAmount",
                table: "Invoice",
                type: "decimal(15,2)",
                precision: 15,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "YukiKey",
                table: "Invoice",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_YukiKey",
                table: "Invoice",
                column: "YukiKey",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoice_YukiKey",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "VatAmount",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "YukiKey",
                table: "Invoice");
        }
    }
}
