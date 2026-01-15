using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.DTOs;
using TaskManager.Models;
using TaskManager.Services.Commands;
using TaskManager.Services.Queries;

namespace TaskManager.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController(ILogger<TaskManagerController> logger, ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            logger.LogInformation("Fetching tasks");

            var tasks = await sender.Send(new GetTasksQuery());

            if (tasks is null)
            {
                logger.LogWarning("No tasks found");
                return NotFound("No tasks");
            }

            logger.LogInformation("Retrieved all tasks");
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            logger.LogInformation("Fetching task with ID: {Id}", id);

            if (id <= 0)
            {
                logger.LogWarning("Invalid ID {Id} provided for fetching task", id);
                return BadRequest("Invalid ID");
            }
            var task = await sender.Send(new GetTaskByIdQuery(id));
            if (task is null)
            {
                logger.LogWarning("Task with ID {Id} not found", id);
                return NotFound();
            }

            logger.LogInformation("Retrieved task with ID: {Id}", id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> CreateTask([FromBody] TaskDTO commandDto)
        {
            logger.LogInformation("Creating new task");

            if (string.IsNullOrEmpty(commandDto.Description) || string.IsNullOrEmpty(commandDto.Title) || string.IsNullOrEmpty(commandDto.Status))
            {
                logger.LogWarning("Task missing Title, Description or Status");
                return BadRequest("Task missing Title, Description or Status");
            }

            var command = new CreateTaskCommand
            (
                commandDto.Title,
                commandDto.Description,
                commandDto.Status,
                commandDto.DueDate,
                DateTime.UtcNow
            );

            var createdTask = await sender.Send(command);
            if (createdTask is null)
            {
                logger.LogWarning("Task not created");
                return Ok();
            }

            logger.LogInformation("Created task with ID: {Id}", createdTask.Id);
            return Ok(createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDTO commandDto)
        {
            logger.LogInformation("Updating task with ID: {Id}", id);

            if (id <= 0)
            {
                logger.LogWarning("Invalid ID {Id} provided for fetching task", id);
                return BadRequest("Invalid ID");
            }

            if (string.IsNullOrEmpty(commandDto.Description) || string.IsNullOrEmpty(commandDto.Title) || string.IsNullOrEmpty(commandDto.Title))
            {
                logger.LogWarning("Missing Title, Description or status for task with ID: {Id}", id);
                return BadRequest("Task missing Title, Description or Status");
            }

            var command = new UpdateTaskCommand
            (
                id,
                commandDto.Title,
                commandDto.Description,
                commandDto.Status,
                commandDto.DueDate
            );
            var updatedTask = await sender.Send(command);

            if (updatedTask is null)
            {
                logger.LogWarning("Task with ID {Id} not found for deletion", id);
                return NotFound();
            }

            logger.LogInformation("Updated task with ID: {Id}", id);
            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            logger.LogInformation("Deleting task with ID: {Id}", id);

            if (id <= 0)
            {
                logger.LogWarning("Invalid ID {Id} for deletion", id);
                return BadRequest("Invalid ID");
            }

            var isDeleted = await sender.Send(new DeleteTaskCommand(id));
            if (isDeleted)
            {
                logger.LogInformation("Deleted task with ID: {Id}", id);
                return NoContent();
            }

            logger.LogWarning("Task with ID {Id} not found for deletion", id);
            return NotFound("Task not found for deletion");
        }
    }
}
