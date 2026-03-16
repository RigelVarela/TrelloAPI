
using TrelloAPI.DTOs.Board;
using TrelloAPI.Models;
using TrelloAPI.Repositories;

namespace TrelloAPI.Services;

public class BoardService : IBoardService
{
    private readonly IBoardRepository _repository;

    public BoardService(IBoardRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BoardDto>> GetAllAsync()
    {
        var boards = await _repository.GetAllAsync();

        // Mapping — Model → DTO
        return boards.Select(b => new BoardDto
        {
            Id = b.Id,
            Title = b.Title,
            Description = b.Description,
            CreationDate = b.CreationDate
        });
    }

    public async Task<BoardDto?> GetByIdAsync(int id)
    {
        var board = await _repository.GetByIdAsync(id);
        if (board == null) return null;

        return new BoardDto
        {
            Id = board.Id,
            Title = board.Title,
            Description = board.Description,
            CreationDate = board.CreationDate
        };
    }

    public async Task<BoardDto> CreateAsync(CrearBoardDto dto)
    {
        // Mapping — DTO → Model
        var board = new Board
        {
            Title = dto.Title,
            Description = dto.Description
        };

        var creado = await _repository.CreateAsync(board);

        // Mapping — Model → DTO
        return new BoardDto
        {
            Id = creado.Id,
            Title = creado.Title,
            Description = creado.Description,
            CreationDate = creado.CreationDate
        };
    }

    public async Task<BoardDto?> UpdateAsync(int id, CrearBoardDto dto)
    {
        var board = await _repository.GetByIdAsync(id);
        if (board == null) return null;

        // Actualizamos solo los campos que vienen del DTO
        board.Title = dto.Title;
        board.Description = dto.Description;

        var actualizado = await _repository.UpdateAsync(board);

        return new BoardDto
        {
            Id = actualizado.Id,
            Title = actualizado.Title,
            Description = actualizado.Description,
            CreationDate = actualizado.CreationDate
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}