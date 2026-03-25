using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Repositories.Interfaces;

public interface ITaskRepository : IGenericRepository<AppTask>
{
    Task<List<AppTask>> GetByUserIdAsync(int userId);
    Task<List<AppTask>> GetCompletedTasksAsync(int userId);
}