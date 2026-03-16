using System.ComponentModel.DataAnnotations;

namespace TrelloAPI.DTOs.TaskList;

public class CrearTaskListDto
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre no debe tener entre 3 y 100")]
    public string Name { get; set; } = string.Empty;
    
    public int BoardId { get; set; }
}