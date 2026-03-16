// Services/ITasksItemService.cs
using TrelloAPI.DTOs.TasksItem;
using TrelloAPI.Models;

namespace TrelloAPI.Services;

public interface ITasksItemService
{
    Task<IEnumerable<TasksItemDto>> GetByTaskListIdAsync(int taskListId);
    Task<TasksItemDto?> GetByIdAsync(int id);
    Task<TasksItemDto> CreateAsync(CrearTasksItemDto dto);
    Task<TasksItemDto?> UpdateAsync(int id, CrearTasksItemDto dto);
    Task<TasksItemDto?> CambiarEstatusAsync(int id, CambiarEstatusDto dto);
    Task<bool> DeleteAsync(int id);
}