using MediatR;
using TaskManager.Data;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.Services.Commands;
using TaskManager.Services.Queries;

namespace TaskManager.Services.Handlers
{
    public class DeleteTaskCommandHandler(ITaskManagerService taskService) : IRequestHandler<DeleteTaskCommand, bool>
    {
        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await taskService.DeleteTask(request.Id);
            return task;
        }
    }
}
