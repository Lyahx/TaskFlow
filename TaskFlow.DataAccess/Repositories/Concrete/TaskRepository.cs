using Microsoft.EntityFrameworkCore;
using TaskFlow.DataAccess.Context;
using TaskFlow.DataAccess.Repositories.Interfaces;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Repositories.Concrete;

public class TaskRepository : GenericRepository<AppTask>, ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<List<AppTask>> GetByUserIdAsync(int userId)
    {
        return _context.AppTasks.Where(x => x.UserId == userId).ToListAsync();
    }

    public Task<List<AppTask>> GetCompletedTasksAsync(int userId)
    {
        return _context.AppTasks.Where(x => x.UserId == userId && x.IsCompleted).ToListAsync();
    }
}