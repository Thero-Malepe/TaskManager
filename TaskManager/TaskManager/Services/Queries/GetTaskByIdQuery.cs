using MediatR;
using TaskManager.Models;

namespace TaskManager.Services.Queries
{
    public record GetTaskByIdQuery(int Id) : IRequest<TaskModel?>;
}
