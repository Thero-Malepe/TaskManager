using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : DbContext(options)
    {
        public DbSet<TaskModel> Tasks => Set<TaskModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var createdAt = new DateTime(2026, 01, 01, 0, 0, 0, DateTimeKind.Utc);
            modelBuilder.Entity<TaskModel>().HasData(
                new TaskModel
                {
                    Id = 1,
                    Title = "Complete project documentation",
                    Description = "Finalize and submit the project documentation by end of the week.",
                    Status = "To Do",
                    DueDate = DateTime.UtcNow.AddDays(1),
                    CreatedAt = createdAt
                },
                new TaskModel
                {
                    Id = 2,
                    Title = "Implement user authentication",
                    Description = "Set up JWT authentication for the API.",
                    Status = "Done",
                    DueDate = DateTime.UtcNow.AddDays(30),
                    CreatedAt = createdAt
                },
                new TaskModel
                {
                    Id = 3,
                    Title = "Design database schema",
                    Description = "Create the initial database schema using EF Core.",
                    Status = "In Progress",
                    DueDate = DateTime.UtcNow.AddDays(14),
                    CreatedAt = createdAt
                },
                new TaskModel
                {
                    Id = 4,
                    Title = "Set up CI/CD pipeline",
                    Description = "Configure GitHub Actions for automated testing and deployment.",
                    Status = "Suspended",
                    DueDate = DateTime.UtcNow.AddDays(5),
                    CreatedAt = createdAt
                },
                new TaskModel
                {
                    Id = 5,
                    Title = "Write unit tests",
                    Description = "Implement unit tests for the service layer.",
                    Status = "To Do",
                    DueDate = DateTime.UtcNow.AddDays(7),
                    CreatedAt = createdAt
                },
                new TaskModel
                {
                    Id = 6,
                    Title = "Create API documentation",
                    Description = "Generate API documentation using Swagger.",
                    Status = "Done",
                    DueDate = DateTime.UtcNow.AddDays(30),
                    CreatedAt = createdAt
                },
                new TaskModel
                {
                    Id = 7,
                    Title = "Deploy to production",
                    Description = "Deploy the application to the production environment.",
                    Status = "Pending",
                    DueDate = DateTime.UtcNow.AddDays(24),
                    CreatedAt = createdAt
                }
            );
        }
    }
}
