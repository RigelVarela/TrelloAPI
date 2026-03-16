using Microsoft.EntityFrameworkCore;
using TrelloAPI.Data;
using TrelloAPI.Models;

namespace TrelloAPI.Repositories;

public class BoardRepository : IBoardRepository
{
    private readonly TrelloDbContext _context;

    public BoardRepository(TrelloDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Board>> GetAllAsync()
    {
        return await _context.Boards
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Board?> GetByIdAsync(int id)
    {
        return await _context.Boards
            .Include(b => b.TaskLists) 
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Board> CreateAsync(Board board)
    {
        _context.Boards.Add(board);
        await _context.SaveChangesAsync();
        return board;
    }

    public async Task<Board> UpdateAsync(Board board)
    {
        _context.Boards.Update(board);
        await _context.SaveChangesAsync();
        return board;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var board = await _context.Boards.FindAsync(id);
        if (board == null) return false;

        _context.Boards.Remove(board);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Boards.AnyAsync(b => b.Id == id);
    }
}