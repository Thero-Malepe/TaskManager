using MediatR;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.Services.Commands;

namespace TaskManager.Services.Handlers
{
    public class UpdateTaskCommandHandler(ITaskManagerService taskService) : IRequestHandler<UpdateTaskCommand, TaskModel?>
    {
        public async Task<TaskModel?> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var existingTask = await taskService.EditTask(request);
            return existingTask;
        }
    }
}
