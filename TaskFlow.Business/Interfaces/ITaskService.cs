using TaskFlow.Entities.Models;

namespace TaskFlow.Business.Interfaces;

public interface ITaskService
{
    Task<List<AppTask>> GetAllTaskAsync(int userId);
    Task<AppTask> GetTaskByIdAsync(int id);
    Task CreateTaskAsync(AppTask task);
    Task UpdateTaskAsync(AppTask task);
    Task DeleteTaskAsync(int id);
    Task<List<AppTask>> GetCompletedTasksAsync(int userId);
}