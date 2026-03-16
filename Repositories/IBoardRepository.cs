using TrelloAPI.Models;
namespace TrelloAPI.Repositories;

public interface IBoardRepository
{
    Task<IEnumerable<Board>> GetAllAsync();
    Task<Board?> GetByIdAsync(int id);
    Task<Board> CreateAsync(Board board);
    Task<Board> UpdateAsync(Board board);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    
}