namespace TrelloAPI.Models;

public class TasksItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public TaskStatus Status { get; set; } = TaskStatus.Pending;

    public int TaskListId { get; set; }
    public TaskList TaskList { get; set; } = null!;
} 