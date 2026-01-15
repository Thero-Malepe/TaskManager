using MediatR;
using TaskManager.Data;
using TaskManager.DTOs;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.Services.Commands;

namespace TaskManager.Services.Handlers
{
    public class CreateTaskCommandHandler(ITaskManagerService taskService) : IRequestHandler<CreateTaskCommand, TaskModel>
    {
        public async Task<TaskModel> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await taskService.CreateTask(request);
            return task;
        }
    }
}
