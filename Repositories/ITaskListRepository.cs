// Repositories/ITaskListRepository.cs
using TrelloAPI.Models;

namespace TrelloAPI.Repositories;

public interface ITaskListRepository
{
    Task<IEnumerable<TaskList>> GetByBoardIdAsync(int boardId);
    Task<TaskList?> GetByIdAsync(int id);
    Task<TaskList> CreateAsync(TaskList taskList);
    Task<TaskList> UpdateAsync(TaskList taskList);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}