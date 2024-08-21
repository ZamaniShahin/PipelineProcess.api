using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PipelineProcess.api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFactoryAggregate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FactoryId",
                table: "Process",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Factory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 64, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Process_FactoryId",
                table: "Process",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Process_Factory_FactoryId",
                table: "Process",
                column: "FactoryId",
                principalTable: "Factory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process_Factory_FactoryId",
                table: "Process");

            migrationBuilder.DropTable(
                name: "Factory");

            migrationBuilder.DropIndex(
                name: "IX_Process_FactoryId",
                table: "Process");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "Process");
        }
    }
}
