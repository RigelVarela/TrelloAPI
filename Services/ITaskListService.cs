using TrelloAPI.DTOs.TaskList;

namespace TrelloAPI.Services;

public interface ITaskListService
{
    Task<IEnumerable<TaskListDto>> GetByBoardIdAsync(int boardId);
    Task<TaskListDto?> GetByIdAsync(int id);
    Task<TaskListDto> CreateAsync(CrearTaskListDto dto);
    Task<TaskListDto?> UpdateAsync(int id, CrearTaskListDto dto);
    Task<bool> DeleteAsync(int id);
}