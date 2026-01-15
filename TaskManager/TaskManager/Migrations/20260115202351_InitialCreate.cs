using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "DueDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Finalize and submit the project documentation by end of the week.", new DateTime(2026, 1, 16, 20, 23, 50, 597, DateTimeKind.Utc).AddTicks(2515), "To Do", "Complete project documentation" },
                    { 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Set up JWT authentication for the API.", new DateTime(2026, 2, 14, 20, 23, 50, 597, DateTimeKind.Utc).AddTicks(2524), "Done", "Implement user authentication" },
                    { 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Create the initial database schema using EF Core.", new DateTime(2026, 1, 29, 20, 23, 50, 597, DateTimeKind.Utc).AddTicks(2526), "In Progress", "Design database schema" },
                    { 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Configure GitHub Actions for automated testing and deployment.", new DateTime(2026, 1, 20, 20, 23, 50, 597, DateTimeKind.Utc).AddTicks(2527), "Suspended", "Set up CI/CD pipeline" },
                    { 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Implement unit tests for the service layer.", new DateTime(2026, 1, 22, 20, 23, 50, 597, DateTimeKind.Utc).AddTicks(2529), "To Do", "Write unit tests" },
                    { 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Generate API documentation using Swagger.", new DateTime(2026, 2, 14, 20, 23, 50, 597, DateTimeKind.Utc).AddTicks(2531), "Done", "Create API documentation" },
                    { 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Deploy the application to the production environment.", new DateTime(2026, 2, 8, 20, 23, 50, 597, DateTimeKind.Utc).AddTicks(2532), "Pending", "Deploy to production" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
