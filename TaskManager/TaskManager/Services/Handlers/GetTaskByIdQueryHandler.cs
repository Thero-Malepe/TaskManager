using MediatR;
using TaskManager.Data;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.Services.Commands;
using TaskManager.Services.Queries;

namespace TaskManager.Services.Handlers
{
    public class GetTaskByIdQueryHandler(ITaskManagerService taskService) : IRequestHandler<GetTaskByIdQuery, TaskModel?>
    {
        public async Task<TaskModel?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await taskService.GetTaskById(request.Id);
            return task;
        }
    }
}
