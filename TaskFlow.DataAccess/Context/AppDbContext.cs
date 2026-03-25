using Microsoft.EntityFrameworkCore;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AppTask> AppTasks { get; set; }
}