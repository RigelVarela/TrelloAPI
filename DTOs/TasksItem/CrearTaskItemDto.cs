using System.ComponentModel.DataAnnotations;
using TrelloAPI.Models;

namespace TrelloAPI.DTOs.TasksItem;

public class CrearTasksItemDto
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 200 caracteres")]
    public string Name { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "La descripción no puede superar 1000 caracteres")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "La fecha de fin es obligatoria")]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "El ID de la lista es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "El ID de la lista debe ser un número positivo")]
    public int TaskListId { get; set; }
}