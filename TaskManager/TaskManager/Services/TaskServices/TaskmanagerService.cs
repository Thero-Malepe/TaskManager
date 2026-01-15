using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.Services.Commands;

namespace TaskManager.Services.TaskServices
{
    public class TaskManagerService(TaskManagerDbContext context) : ITaskManagerService
    {
        public async Task<TaskModel> CreateTask(CreateTaskCommand task)
        {
            var taskModel = new TaskModel
            {
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                CreatedAt = task.CreatedAt,
                DueDate = task.DueDate
            };
            await context.Tasks.AddAsync(taskModel);
            await context.SaveChangesAsync();
            return taskModel;
        }

        public async Task<List<TaskModel>> GetTasks()
        {
            return await context.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            var taskModel = await context.Tasks.FindAsync(id);
            return taskModel;
        }

        public async Task<TaskModel> EditTask(UpdateTaskCommand task)
        {
            var existingTask = await context.Tasks.FindAsync(task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.Status = task.Status;
                existingTask.DueDate = task.DueDate;

                await context.SaveChangesAsync();
                return existingTask;
            }

            return existingTask;
        }
        public async Task<bool> DeleteTask(int id)
        {
            var task = await context.Tasks.FindAsync(id);
            if (task == null)
            {
                return false;
            }

            context.Tasks.Remove(task);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
