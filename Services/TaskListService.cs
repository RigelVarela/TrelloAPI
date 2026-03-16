// Services/TaskListService.cs
using TrelloAPI.DTOs.TaskList;
using TrelloAPI.Models;
using TrelloAPI.Repositories;

namespace TrelloAPI.Services;

public class TaskListService : ITaskListService
{
    private readonly ITaskListRepository _repository;
    private readonly IBoardRepository _boardRepository;

    // Necesitamos el BoardRepository para verificar que el Board existe
    // antes de crear una lista — eso es una regla de negocio
    public TaskListService(
        ITaskListRepository repository,
        IBoardRepository boardRepository)
    {
        _repository = repository;
        _boardRepository = boardRepository;
    }

    public async Task<IEnumerable<TaskListDto>> GetByBoardIdAsync(int boardId)
    {
        var lists = await _repository.GetByBoardIdAsync(boardId);

        return lists.Select(l => new TaskListDto
        {
            Id = l.Id,
            Name = l.Name,
            BoardId = l.BoardId
        });
    }

    public async Task<TaskListDto?> GetByIdAsync(int id)
    {
        var list = await _repository.GetByIdAsync(id);
        if (list == null) return null;

        return new TaskListDto
        {
            Id = list.Id,
            Name = list.Name,
            BoardId = list.BoardId
        };
    }

    public async Task<TaskListDto> CreateAsync(CrearTaskListDto dto)
    {
        // Regla de negocio — no puedes crear una lista
        // si el tablero al que pertenece no existe
        var boardExiste = await _boardRepository.ExistsAsync(dto.BoardId);
        if (!boardExiste)
            throw new ArgumentException($"No existe un tablero con ID {dto.BoardId}");

        var taskList = new TaskList
        {
            Name = dto.Name,
            BoardId = dto.BoardId
        };

        var creada = await _repository.CreateAsync(taskList);

        return new TaskListDto
        {
            Id = creada.Id,
            Name = creada.Name,
            BoardId = creada.BoardId
        };
    }

    public async Task<TaskListDto?> UpdateAsync(int id, CrearTaskListDto dto)
    {
        var list = await _repository.GetByIdAsync(id);
        if (list == null) return null;

        list.Name = dto.Name;

        var actualizada = await _repository.UpdateAsync(list);

        return new TaskListDto
        {
            Id = actualizada.Id,
            Name = actualizada.Name,
            BoardId = actualizada.BoardId
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}