using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Business.Interfaces;
using TaskFlow.Entities.DTOs.Task;
using TaskFlow.Entities.Models;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var tasks = await _service.GetAllTaskAsync(userId);
        var dtos = tasks.Select(task => new TaskResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Priority = task.Priority,
            IsCompleted = task.IsCompleted,
            DueDate = task.DueDate,
            CreatedAt = task.CreatedAt
        }).ToList();
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _service.GetTaskByIdAsync(id);
        if (task == null)
            return NotFound();
        var dto = new TaskResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Priority = task.Priority,
            IsCompleted = task.IsCompleted,
            DueDate = task.DueDate,
            CreatedAt = task.CreatedAt
        };
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask(CreateTaskDto dto)
    {
        var task = new AppTask
        {
            Title = dto.Title,
            Description = dto.Description,
            Priority = dto.Priority,
            DueDate = dto.DueDate
        };
        await _service.CreateTaskAsync(task);
        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id,AppTask task)
    {
        await _service.UpdateTaskAsync(task);
        return Ok(task);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _service.GetTaskByIdAsync(id);
        if (task==null)
            return NotFound();
        await _service.DeleteTaskAsync(id);
        return Ok();
    }
}