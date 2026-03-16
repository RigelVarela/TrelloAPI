using TrelloAPI.Models;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace TrelloAPI.DTOs.TasksItem;

public class TasksItemDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public TaskItemStatus Status { get; set; }
    public int TaskListId { get; set; }
}