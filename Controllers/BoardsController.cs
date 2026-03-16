// Controllers/BoardsController.cs
using Microsoft.AspNetCore.Mvc;
using TrelloAPI.DTOs.Board;
using TrelloAPI.Services;

namespace TrelloAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoardsController : ControllerBase
{
    private readonly IBoardService _service;

    public BoardsController(IBoardService service)
    {
        _service = service;
    }

    // GET api/boards
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var boards = await _service.GetAllAsync();
        return Ok(boards);
    }

    // GET api/boards/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var board = await _service.GetByIdAsync(id);

        if (board == null)
            return NotFound(new { error = $"No existe un tablero con ID {id}" });

        return Ok(board);
    }

    // POST api/boards
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearBoardDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var creado = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // PUT api/boards/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CrearBoardDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var actualizado = await _service.UpdateAsync(id, dto);

            if (actualizado == null)
                return NotFound(new { error = $"No existe un tablero con ID {id}" });

            return Ok(actualizado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // DELETE api/boards/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.DeleteAsync(id);

        if (!eliminado)
            return NotFound(new { error = $"No existe un tablero con ID {id}" });

        return NoContent();
    }
}