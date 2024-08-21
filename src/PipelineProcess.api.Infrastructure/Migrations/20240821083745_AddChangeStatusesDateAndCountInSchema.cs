using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PipelineProcess.api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChangeStatusesDateAndCountInSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Count",
                table: "Schema",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "AdminAcceptStatusChangedAt",
                table: "ProcessSheetEntity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StatusChangedAt",
                table: "ProcessSheetEntity",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Schema");

            migrationBuilder.DropColumn(
                name: "AdminAcceptStatusChangedAt",
                table: "ProcessSheetEntity");

            migrationBuilder.DropColumn(
                name: "StatusChangedAt",
                table: "ProcessSheetEntity");
        }
    }
}
