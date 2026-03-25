using Microsoft.EntityFrameworkCore;
using TaskFlow.DataAccess.Context;
using TaskFlow.DataAccess.Repositories.Interfaces;

namespace TaskFlow.DataAccess.Repositories.Concrete;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _context;
    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<T>> GetAllAsync()
    {
        return _context.Set<T>().ToListAsync();
    }

    public Task<T> GetByIdAsync(int id)
    {
        return _context.Set<T>().FindAsync(id).AsTask();
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity).AsTask();
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        return _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}