using MediatR;
using TaskManager.DTOs;
using TaskManager.Models;

namespace TaskManager.Services.Commands
{
    public record UpdateTaskCommand(int Id, string Title, string Description, string Status, DateTime DueDate) : IRequest<TaskModel>;
}
