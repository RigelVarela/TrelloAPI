using System.ComponentModel.DataAnnotations;
using TrelloAPI.Models;

namespace TrelloAPI.DTOs.TasksItem;

public class CambiarEstatusDto
{
    [Required(ErrorMessage = "El estatus es obligatorio")]
    public TaskItemStatus Status { get; set; }
}
