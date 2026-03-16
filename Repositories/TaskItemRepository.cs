// Repositories/TasksItemRepository.cs
using Microsoft.EntityFrameworkCore;
using TrelloAPI.Data;
using TrelloAPI.Models;

namespace TrelloAPI.Repositories;

public class TasksItemRepository : ITasksItemRepository
{
    private readonly TrelloDbContext _context;

    public TasksItemRepository(TrelloDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TasksItem>> GetByTaskListIdAsync(int taskListId)
    {
        return await _context.Tasks
            .Where(t => t.TaskListId == taskListId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<TasksItem?> GetByIdAsync(int id)
    {
        return await _context.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<TasksItem> CreateAsync(TasksItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<TasksItem> UpdateAsync(TasksItem task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return false;

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Tasks.AnyAsync(t => t.Id == id);
    }
}