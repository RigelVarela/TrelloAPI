// Controllers/TaskListsController.cs
using Microsoft.AspNetCore.Mvc;
using TrelloAPI.DTOs.TaskList;
using TrelloAPI.Services;

namespace TrelloAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskListsController : ControllerBase
{
    private readonly ITaskListService _service;

    public TaskListsController(ITaskListService service)
    {
        _service = service;
    }

    // GET api/tasklists/board/1
    [HttpGet("board/{boardId}")]
    public async Task<IActionResult> GetByBoardId(int boardId)
    {
        var lists = await _service.GetByBoardIdAsync(boardId);
        return Ok(lists);
    }

    // GET api/tasklists/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var list = await _service.GetByIdAsync(id);

        if (list == null)
            return NotFound(new { error = $"No existe una lista con ID {id}" });

        return Ok(list);
    }

    // POST api/tasklists
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearTaskListDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var creada = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creada.Id }, creada);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // PUT api/tasklists/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CrearTaskListDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var actualizada = await _service.UpdateAsync(id, dto);

            if (actualizada == null)
                return NotFound(new { error = $"No existe una lista con ID {id}" });

            return Ok(actualizada);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // DELETE api/tasklists/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.DeleteAsync(id);

        if (!eliminado)
            return NotFound(new { error = $"No existe una lista con ID {id}" });

        return NoContent();
    }
}