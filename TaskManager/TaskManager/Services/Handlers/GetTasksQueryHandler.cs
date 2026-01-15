using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.Services.Queries;

namespace TaskManager.Services.Handlers
{
    public class GetTasksQueryHandler(ITaskManagerService taskService) : IRequestHandler<GetTasksQuery, List<TaskModel>?>
    {
        public async Task<List<TaskModel>?> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var task = await taskService.GetTasks();
            return task;
        }
    }
}
