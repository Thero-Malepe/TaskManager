using MediatR;
using TaskManager.Models;

namespace TaskManager.Services.Queries
{
    public record GetTasksQuery : IRequest<List<TaskModel>>;
}
