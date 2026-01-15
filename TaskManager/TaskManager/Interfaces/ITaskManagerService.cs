using TaskManager.Models;
using TaskManager.Services.Commands;

namespace TaskManager.Interfaces
{
    public interface ITaskManagerService
    {
        Task<List<TaskModel>> GetTasks();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> EditTask(UpdateTaskCommand task);
        Task<TaskModel> CreateTask(CreateTaskCommand task);
        Task<bool> DeleteTask(int id);
    }
}
