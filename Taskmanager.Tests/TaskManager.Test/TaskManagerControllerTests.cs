using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TaskManager.Controllers;
using TaskManager.DTOs;
using TaskManager.Models;
using TaskManager.Services.Commands;
using TaskManager.Services.Queries;

namespace TaskManagerTests
{
    public class TaskManagerControllerTests
    {
        private readonly Mock<ILogger<TaskManagerController>> _loggerMock;
        private readonly Mock<ISender> _senderMock;
        private readonly TaskManagerController _controller;

        public TaskManagerControllerTests()
        {
            _loggerMock = new Mock<ILogger<TaskManagerController>>();
            _senderMock = new Mock<ISender>();

            _controller = new TaskManagerController(
                _loggerMock.Object,
                _senderMock.Object
            );
        }

        [Fact]
        public async Task GetTaskById_ValidId_ReturnsOk()
        {
            // Arrange
            var task = new TaskModel { Id = 1, Title = "Complete project documentation" };

            _senderMock
                .Setup(s => s.Send(It.IsAny<GetTaskByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(task);

            // Act
            var result = await _controller.GetTaskById(1);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().Be(task);
        }

        [Fact]
        public async Task GetTaskById_InvalidId_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.GetTaskById(0);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
            _senderMock.Verify(s => s.Send(It.IsAny<GetTaskByIdQuery>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetTaskById_TaskNotFound_ReturnsNotFound()
        {
            // Arrange
            _senderMock
                .Setup(s => s.Send(It.IsAny<GetTaskByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((TaskModel?)null);

            // Act
            var result = await _controller.GetTaskById(99);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task CreateTask_ValidDto_ReturnsOkWithTask()
        {
            // Arrange
            var dto = new TaskDTO
            {
                Title = "Title",
                Description = "Desc",
                Status = "Open",
                DueDate = DateTime.UtcNow.AddDays(3)
            };

            var createdTask = new TaskModel
            {
                Id = 1,
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
                DueDate = dto.DueDate
            };

            _senderMock
                .Setup(s => s.Send(It.IsAny<CreateTaskCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(createdTask);

            // Act
            var result = await _controller.CreateTask(dto);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().Be(createdTask);

            _senderMock.Verify(
                s => s.Send(It.Is<CreateTaskCommand>(c =>
                    c.Title == dto.Title &&
                    c.Description == dto.Description &&
                    c.Status == dto.Status),
                It.IsAny<CancellationToken>()),
                Times.Once);
        }


        [Fact]
        public async Task CreateTask_MissingTitle_ReturnsBadRequest()
        {
            // Arrange
            var dto = new TaskDTO
            {
                Title = "",
                Description = "Desc",
                Status = "Open"
            };

            // Act
            var result = await _controller.CreateTask(dto);

            // Assert
            var badRequest = result.Result as BadRequestObjectResult;
            badRequest.Should().NotBeNull();
            badRequest!.Value.Should().Be("Task missing Title, Description or Status");

            _senderMock.Verify(
                s => s.Send(It.IsAny<CreateTaskCommand>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }


        [Fact]
        public async Task UpdateTask_ValidRequest_ReturnsOk()
        {
            // Arrange
            var dto = new TaskDTO
            {
                Title = "Updated",
                Description = "Updated Desc",
                Status = "Done",
                DueDate = DateTime.UtcNow
            };

            var updatedTask = new TaskModel { Id = 1, Title = "Updated" };

            _senderMock
                .Setup(s => s.Send(It.IsAny<UpdateTaskCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(updatedTask);

            // Act
            var result = await _controller.UpdateTask(1, dto);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().Be(updatedTask);
        }

        [Fact]
        public async Task DeleteTask_ExistingTask_ReturnsNoContent()
        {
            // Arrange
            _senderMock
                .Setup(s => s.Send(It.IsAny<DeleteTaskCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteTask(1);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task DeleteTask_TaskNotFound_ReturnsNotFound()
        {
            // Arrange
            _senderMock
                .Setup(s => s.Send(It.IsAny<DeleteTaskCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteTask(99);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}