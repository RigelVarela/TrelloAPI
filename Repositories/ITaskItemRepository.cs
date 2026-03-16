using TrelloAPI.Models;
namespace TrelloAPI.Repositories;

public interface ITasksItemRepository
{
    Task<IEnumerable<TasksItem>> GetByTaskListIdAsync(int taskListId);
    Task<TasksItem?> GetByIdAsync(int id);
    Task<TasksItem> CreateAsync(TasksItem task);
    Task<TasksItem> UpdateAsync(TasksItem task);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}