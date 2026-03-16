using TrelloAPI.DTOs.Board;
namespace TrelloAPI.Services;

public interface IBoardService
{
    Task<IEnumerable<BoardDto>> GetAllAsync();
    Task<BoardDto?> GetByIdAsync(int id);
    Task<BoardDto> CreateAsync(CrearBoardDto dto);
    Task<BoardDto?> UpdateAsync(int id, CrearBoardDto dto);
    Task<bool> DeleteAsync(int id);
}