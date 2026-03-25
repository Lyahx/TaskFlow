using Microsoft.AspNetCore.Mvc;
using TaskFlow.Business.Interfaces;
using TaskFlow.Entities.Models;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks(int userid)
    {
        var tasks = await _service.GetAllTaskAsync(userid);
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _service.GetTaskByIdAsync(id);
        if (task == null)
            return NotFound();
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask(AppTask task)
    {
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
        if (_service.GetTaskByIdAsync(id)==null)
            return NotFound();
        await _service.DeleteTaskAsync(id);
        return Ok();
    }
}