// Services/TasksItemService.cs
using TrelloAPI.DTOs.TasksItem;
using TrelloAPI.Models;
using TrelloAPI.Repositories;

namespace TrelloAPI.Services;

public class TasksItemService : ITasksItemService
{
    private readonly ITasksItemRepository _repository;
    private readonly ITaskListRepository _taskListRepository;

    public TasksItemService(
        ITasksItemRepository repository,
        ITaskListRepository taskListRepository)
    {
        _repository = repository;
        _taskListRepository = taskListRepository;
    }

    public async Task<IEnumerable<TasksItemDto>> GetByTaskListIdAsync(int taskListId)
    {
        var tasks = await _repository.GetByTaskListIdAsync(taskListId);

        return tasks.Select(t => new TasksItemDto
        {
            Id = t.Id,
            Name = t.Name,
            Description = t.Description,
            StartDate = t.StartDate,
            EndDate = t.EndDate,
            CreatedDate = t.CreatedDate,
            Status = t.Status,
            TaskListId = t.TaskListId
        });
    }

    public async Task<TasksItemDto?> GetByIdAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null) return null;

        return new TasksItemDto
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            StartDate = task.StartDate,
            EndDate = task.EndDate,
            CreatedDate = task.CreatedDate,
            Status = task.Status,
            TaskListId = task.TaskListId
        };
    }

    public async Task<TasksItemDto> CreateAsync(CrearTasksItemDto dto)
    {
        // Regla de negocio — la lista debe existir
        var listaExiste = await _taskListRepository.ExistsAsync(dto.TaskListId);
        if (!listaExiste)
            throw new ArgumentException($"No existe una lista con ID {dto.TaskListId}");

        // Regla de negocio — la fecha de fin no puede ser antes que la de inicio
        if (dto.EndDate <= dto.StartDate)
            throw new ArgumentException("La fecha de fin debe ser posterior a la fecha de inicio");

        var task = new TasksItem
        {
            Name = dto.Name,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            TaskListId = dto.TaskListId
        };

        var creada = await _repository.CreateAsync(task);

        return new TasksItemDto
        {
            Id = creada.Id,
            Name = creada.Name,
            Description = creada.Description,
            StartDate = creada.StartDate,
            EndDate = creada.EndDate,
            CreatedDate = creada.CreatedDate,
            Status = creada.Status,
            TaskListId = creada.TaskListId
        };
    }

    public async Task<TasksItemDto?> UpdateAsync(int id, CrearTasksItemDto dto)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null) return null;

        if (dto.EndDate <= dto.StartDate)
            throw new ArgumentException("La fecha de fin debe ser posterior a la fecha de inicio");

        task.Name = dto.Name;
        task.Description = dto.Description;
        task.StartDate = dto.StartDate;
        task.EndDate = dto.EndDate;
        task.TaskListId = dto.TaskListId;

        var actualizada = await _repository.UpdateAsync(task);

        return new TasksItemDto
        {
            Id = actualizada.Id,
            Name = actualizada.Name,
            Description = actualizada.Description,
            StartDate = actualizada.StartDate,
            EndDate = actualizada.EndDate,
            CreatedDate = actualizada.CreatedDate,
            Status = actualizada.Status,
            TaskListId = actualizada.TaskListId
        };
    }

    public async Task<TasksItemDto?> CambiarEstatusAsync(int id, CambiarEstatusDto dto)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null) return null;

        // Regla de negocio — una tarea completada no puede volver a Pending
        if (task.Status == Models.TaskItemStatus.Completed && dto.Status == Models.TaskItemStatus.Pending)
            throw new ArgumentException("Una tarea completada no puede volver a estado Pending");

        task.Status = dto.Status;

        var actualizada = await _repository.UpdateAsync(task);

        return new TasksItemDto
        {
            Id = actualizada.Id,
            Name = actualizada.Name,
            Description = actualizada.Description,
            StartDate = actualizada.StartDate,
            EndDate = actualizada.EndDate,
            CreatedDate = actualizada.CreatedDate,
            Status = actualizada.Status,
            TaskListId = actualizada.TaskListId
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}