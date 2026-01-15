using MediatR;
using TaskManager.Models;

namespace TaskManager.Services.Commands
{
    public record DeleteTaskCommand(int Id) : IRequest<bool>;
}
