using TaskFlow.Business.Interfaces;
using TaskFlow.DataAccess.Repositories.Interfaces;
using TaskFlow.Entities.Models;

namespace TaskFlow.Business.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public Task<List<AppTask>> GetAllTaskAsync(int userId)
    {
        return _repository.GetByUserIdAsync(userId);
    }

    public Task<AppTask> GetTaskByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task CreateTaskAsync(AppTask task)
    {
        task.CreatedAt = DateTime.UtcNow;
        return _repository.AddAsync(task);
    }

    public Task UpdateTaskAsync(AppTask task)
    {
        return _repository.UpdateAsync(task);
    }

    public Task DeleteTaskAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }

    public Task<List<AppTask>> GetCompletedTasksAsync(int userId)
    {
        return _repository.GetCompletedTasksAsync(userId);
    }
}