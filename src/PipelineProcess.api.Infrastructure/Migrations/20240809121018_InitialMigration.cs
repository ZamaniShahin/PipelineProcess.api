using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PipelineProcess.api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 64, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 64, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    SchemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Schema_SchemaId",
                        column: x => x.SchemaId,
                        principalTable: "Schema",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectTodoItemEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AdminAcceptStatus = table.Column<int>(type: "int", nullable: false),
                    TodoItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTodoItemEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTodoItemEntity_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectTodoItemEntity_TodoItem_TodoItemId",
                        column: x => x.TodoItemId,
                        principalTable: "TodoItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_SchemaId",
                table: "Project",
                column: "SchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTodoItemEntity_ProjectId",
                table: "ProjectTodoItemEntity",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTodoItemEntity_TodoItemId",
                table: "ProjectTodoItemEntity",
                column: "TodoItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTodoItemEntity");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "TodoItem");

            migrationBuilder.DropTable(
                name: "Schema");
        }
    }
}
