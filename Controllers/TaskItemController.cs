// Controllers/TasksItemsController.cs
using Microsoft.AspNetCore.Mvc;
using TrelloAPI.DTOs.TasksItem;
using TrelloAPI.Services;

namespace TrelloAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksItemsController : ControllerBase
{
    private readonly ITasksItemService _service;

    public TasksItemsController(ITasksItemService service)
    {
        _service = service;
    }

    // GET api/tasksitems/list/1
    [HttpGet("list/{taskListId}")]
    public async Task<IActionResult> GetByTaskListId(int taskListId)
    {
        var tasks = await _service.GetByTaskListIdAsync(taskListId);
        return Ok(tasks);
    }

    // GET api/tasksitems/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _service.GetByIdAsync(id);

        if (task == null)
            return NotFound(new { error = $"No existe una tarea con ID {id}" });

        return Ok(task);
    }

    // POST api/tasksitems
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearTasksItemDto dto)
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

    // PUT api/tasksitems/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CrearTasksItemDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var actualizada = await _service.UpdateAsync(id, dto);

            if (actualizada == null)
                return NotFound(new { error = $"No existe una tarea con ID {id}" });

            return Ok(actualizada);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // PATCH api/tasksitems/1/status
    // Usamos PATCH porque solo modificamos un campo, no el objeto completo
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> CambiarEstatus(int id, [FromBody] CambiarEstatusDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var actualizada = await _service.CambiarEstatusAsync(id, dto);

            if (actualizada == null)
                return NotFound(new { error = $"No existe una tarea con ID {id}" });

            return Ok(actualizada);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // DELETE api/tasksitems/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.DeleteAsync(id);

        if (!eliminado)
            return NotFound(new { error = $"No existe una tarea con ID {id}" });

        return NoContent();
    }
}