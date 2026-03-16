using Microsoft.EntityFrameworkCore;
using TrelloAPI.Data;
using TrelloAPI.Models;

namespace TrelloAPI.Repositories;

public class TaskListRepository : ITaskListRepository
{
    private readonly TrelloDbContext _context;

    public TaskListRepository(TrelloDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskList>> GetByBoardIdAsync(int boardId)
    {
        return await _context.Lists
            .Where(l => l.BoardId == boardId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<TaskList?> GetByIdAsync(int id)
    {
        return await _context.Lists
            .Include(l => l.Tasks)
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<TaskList> CreateAsync(TaskList taskList)
    {
        _context.Lists.Add(taskList);
        await _context.SaveChangesAsync();
        return taskList;
    }

    public async Task<TaskList> UpdateAsync(TaskList taskList)
    {
        _context.Lists.Update(taskList);
        await _context.SaveChangesAsync();
        return taskList;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var taskList = await _context.Lists.FindAsync(id);
        if (taskList == null) return false;

        _context.Lists.Remove(taskList);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Lists.AnyAsync(l => l.Id == id);
    }
}