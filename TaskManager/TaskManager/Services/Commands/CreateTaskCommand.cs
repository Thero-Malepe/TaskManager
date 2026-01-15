using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskManager.DTOs;
using TaskManager.Models;

namespace TaskManager.Services.Commands
{
    public record CreateTaskCommand(string Title, string Description, string Status, DateTime DueDate, DateTime CreatedAt) : IRequest<TaskModel>;
}
